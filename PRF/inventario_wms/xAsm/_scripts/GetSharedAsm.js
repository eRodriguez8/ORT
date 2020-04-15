// Obtiene assemblies compartidos y los copia en subcarpetas de xAsm.
//
// Modos de operación:
//
//  1) Si se invoca con dos parámetros  (desde la configuración de CruiseControl)
//     Copia en la subcarpeta de xAsm que se indica como 1er. parametro, 
//     el contenido de la carpeta especificada como 2do. parametro; por ej.:
//
//     cscript xAsm\_scripts\GetSharedAsm.js "InvocationFramework" "..\..\InvocationFramework\xAsmOut"
//
//  2) Si el primer parámetro es -Remote     (invocado en la accion Rebuild del proyecto)
//     y además existe el archivo xAsmSyncRemote.xml y/o xAsmSyncRemoteCommon.xml,
//     obtiene el path remoto (de cualquiera de los dos, con prioridad al xAsmSyncRemote)
//     y una lista de subcarpetas (combinada de ambos archivos), ej.:
//      <config>
//         <updateFolders sourceSolutionPath="\\jupiter\BuildsCc\Tenaris\Milestone3\Cms\Main\CmsSln\">
//            <folder name="FlexCore" />
//            <folder name="SIF" />
//         </updateFolders>
//      </config>
//
//  3) Si el primer parámetro es -Local      (invocado en las acciones Build y Rebuild del proyecto)
//     y además el archivo xAsmSyncLocal.xml existe,
//     obtiene de ese archivo una lista de subcarpetas y su path de origen, ej.:
//      <config>
//         <updateFolders>
//            <folder name="FlexCore" path="D:\02-Codigo\FlexCoreWksp\FlexCore\xAsmOut" />
//            <folder name="SIF" path="..\..\..\ServicesInvocationFramework\xAsmOut" />
//         </updateFolders>
//      </config>
//
//     Autor: José Marcenaro - Tercer Planeta - josem@tercerplaneta.com
//     Fecha: 2008.05.27

var mode;
var doc;
var fso;                 // File System Object
var xAsmPath;        // path a la carpeta raiz de la solucion, sin \ final
var subFolder;
var sourcePath;
var i;
var attr;

if (!prepare())
    WScript.Quit(0);

if (mode == "singleFolder") {
    copyFiles(xAsmPath + "\\" + subFolder, sourcePath, false);
    WScript.Quit(0);
}

if (mode == "-Remote") {
    WScript.StdOut.WriteLine("- Getting shared assemblies from Remote folders");
    var nodes = doc.selectNodes("config/updateFolders/folder");
    for (i = 0; i < nodes.length; ++i) {
        var attrs = nodes[i].attributes;
        subFolder = attrs.getNamedItem("name").value;
        copyFiles(xAsmPath + "\\" + subFolder, sourcePath + subFolder, false);
    }
    WScript.StdOut.WriteLine("");
    doc = null;
    WScript.Quit(0);
}

if (mode == "-Local") {
    WScript.StdOut.WriteLine("- Getting shared assemblies from Local folders");
    var nodes = doc.selectNodes("config/updateFolders/folder");
    for (i = 0; i < nodes.length; ++i) {
        var attrs = nodes[i].attributes;
        subFolder = attrs.getNamedItem("name").value;
        sourcePath = attrs.getNamedItem("path").value;
        attr = attrs.getNamedItem("additive");
        copyFiles(xAsmPath + "\\" + subFolder, sourcePath, (attr != null && attr.value == "true"));
    }
    WScript.StdOut.WriteLine("");
    doc = null;
    WScript.Quit(0);
}

function copyFiles(targetFolder, sourceFolder, additive) {

    if (!additive)
        deleteFiles(targetFolder);

    try {

        if (!fso.FolderExists(targetFolder))
            makeDir(targetFolder);

        var folder = fso.GetFolder(sourceFolder);
        var files = new Enumerator(folder.files);

        WScript.StdOut.WriteLine("   Copying " + folder.path + " to " + targetFolder);
        for (; !files.atEnd(); files.moveNext()) {
            var filePath = files.item() + "";
            var fileName = fso.GetFileName(filePath);
            if (fso.GetExtensionName(fileName) == "tmp")
                continue;
            // WScript.StdOut.WriteLine("\t"+filePath);
            var targetFile = targetFolder + "\\" + fileName;
            if (fso.FileExists(targetFile)) {
                var f = fso.GetFile(targetFile);
                if (f.Attributes & 1 == 1) {
                    // Quitar el atributo de solo lectura
                    f.Attributes = f.Attributes - 1;
                }
            }

            fso.CopyFile(filePath, targetFile, true);
        }
    }
    catch (e) {
        WScript.StdOut.WriteLine("***ERROR: Unable to copy files from " + sourceFolder + " to " + targetFolder + "\n\n" + e.message);
        WScript.Quit(-1);
    }
}

function deleteFiles(targetFolder) {
    if (!fso.FolderExists(targetFolder))
        return;
    var folder = fso.GetFolder(targetFolder);
    var files = new Enumerator(folder.files);
    // WScript.StdOut.WriteLine("\nDeleting from "+targetFolder+":");
    try {
        for (; !files.atEnd(); files.moveNext()) {
            var filePath = files.item() + "";
            var fileName = fso.GetFileName(filePath);
            // WScript.StdOut.Write(fileName+",");

            if (fso.FileExists(filePath)) {
                var f = fso.GetFile(filePath);
                if (f.Attributes & 1 == 1) {
                    // Quitar el atributo de solo lectura
                    f.Attributes = f.Attributes - 1;
                }
                fso.DeleteFile(filePath);
            }
        }
    }
    catch (e) {
        WScript.StdOut.WriteLine("Unable to delete files from " + targetFolder + "\n\n" + e.message);
        WScript.Quit(-1);
    }
}

function makeDir(folder) {
    var parent = fso.GetParentFolderName(folder);
    if (!fso.FolderExists(parent))
        makeDir(parent);
    fso.CreateFolder(folder);
}

function prepare() {
    fso = new ActiveXObject('Scripting.FileSystemObject');
    xAsmPath = fso.GetParentFolderName(fso.GetParentFolderName(WScript.ScriptFullName));
    if (WScript.Arguments.Length < 1) {
        WScript.StdOut.WriteLine("***ERROR: missing parameters in " + fso.GetFileName(WScript.ScriptFullName) + "\n\n");
        WScript.Quit(-1);
    }

    if (WScript.Arguments.Length >= 2) {
        mode = "singleFolder";
        subFolder = WScript.Arguments(0);
        sourcePath = WScript.Arguments(1);
        return true; // process
    }
    mode = WScript.Arguments(0);
    var xmlFile;

    if (mode == "-Remote") {
        sourcePath = null;
        // primero intenta procesar el archivo common
        var doc1 = doc = parseXml(xAsmPath + "\\xAsmSyncRemoteCommon.xml");

        // despues intenta procesar el archivo especifico
        var doc2 = parseXml(xAsmPath + "\\xAsmSyncRemote.xml");
        if (doc2 != null) {
            // si existen ambos, realiza el merge
            if (doc1 != null) {
                var node = doc2.selectSingleNode("config/updateFolders");
                var nodes = doc1.selectNodes("config/updateFolders/folder");
                for (i = 0; i < nodes.length; ++i) {
                    var attrs = nodes[i].attributes;
                    subFolder = attrs.getNamedItem("name").value;
                    var elem = doc.createElement("folder");
                    elem.setAttribute("name", subFolder);
                    node.appendChild(elem);
                }
            }
            doc = doc2;
        }

        if (doc == null)
            return false;  // do not process

        if (sourcePath == null) {
            WScript.StdOut.WriteLine("***ERROR: Missing attribute sourceSolutionPath in config/updateFolder\n\n");
            WScript.Quit(-1);
        }


    }
    else if (mode == "-Local") {
        xmlFile = xAsmPath + "\\xAsmSyncLocal.xml";
        if (!fso.FileExists(xmlFile))
            return false;  // do not process

        doc = WScript.CreateObject("MSXML2.DomDocument");
        doc.load(xmlFile);
    }
    else {
        WScript.StdOut.WriteLine("***ERROR: wrong parameter '" + mode + "' in " + fso.GetFileName(WScript.ScriptFullName) + "\n\n");
        WScript.Quit(-1);
    }

    return true;
}

function parseXml(path) {
    if (fso.FileExists(path)) {
        var xDoc = WScript.CreateObject("MSXML2.DomDocument");
        xDoc.load(path);
        var n = xDoc.selectSingleNode("config/updateFolders");

        if (n != null) {
            var at = n.attributes.getNamedItem("sourceSolutionPath");
            if (at != null) {
                if (sourcePath != null)
                    WScript.StdOut.WriteLine("** Duplicate definition for sourceSolutionPath, using " + at.value + "xAsm\\");
                sourcePath = at.value;

                // reemplaza expresiones de la forma "$(parentN)"
                if (sourcePath.substr(sourcePath.length - 1, 1) != '\\')
                    sourcePath += "\\";

                var j;
                while ((j = sourcePath.indexOf("$(parent")) >= 0) {
                    var niveles = eval(sourcePath.substr(j + 8, 1));
                    var s = xAsmPath;
                    for (var i = 0; i < niveles; i++)
                        s = fso.GetParentFolderName(s);
                    s = fso.GetBaseName(s);
                    sourcePath = sourcePath.substr(0, j) + s + sourcePath.substr(j + 10);
                }
                sourcePath += "xAsm\\";

            }

            if (n.selectNodes("folder").length > 0)
                return xDoc;
        }
    }
    return null;
}
