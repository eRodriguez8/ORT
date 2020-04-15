// Script de post-build de un proyecto
// Copia los assemblies a la carpeta Services en los publishers que corresponda
//
// USO - asignar en el evento de post-build de CADA proyecto:
//         cscript $(ProjectDir)..\xAsm\_scripts\CopyAsmSvc.js $(ProjectDir)..\..\PublisherSln\GenericPublisher
//
// Utilizarlo solamente en los assemblies de servicios.
//
// Autor: José Marcenaro - Tercer Planeta - josem@tercerplaneta.com
// Fecha: 2007.01.23
// Modif: 2008.10.12

var fso;                 // File System Object

prepare();

var publisherPath = WScript.Arguments(0);
copyFiles( publisherPath+"\\Services\\", "InvocationFramework.");
restartWebApp( publisherPath);


function copyFiles(targetFolder, notStartingWith) 
{
    if (!fso.FolderExists(targetFolder))
        makeDir(targetFolder);

    var folder = fso.GetFolder(".");
    var files = new Enumerator(folder.files);
    WScript.StdOut.WriteLine("Copying to "+targetFolder+":");
    try {
        for (; !files.atEnd(); files.moveNext()) 
        {
            var filePath = files.item() + "";
            var fileName = fso.GetFileName(filePath);
            if (notStartingWith>"" && fso.GetFileName(filePath).substr(0,notStartingWith.length)==notStartingWith)
                continue;
            WScript.StdOut.WriteLine("\t"+fileName);
            fso.CopyFile(filePath,targetFolder+fileName,true);
        }
    }
    catch( e ) {
        WScript.Echo("Unable to copy files to "+targetFolder+"\n\n"+e.message);
    }
}

function makeDir(folder)
{
    var parent=fso.GetParentFolderName(folder);
    if (!fso.FolderExists(parent))
        makeDir(parent);
    fso.CreateFolder(folder);
}

function prepare() 
{
    fso = new ActiveXObject('Scripting.FileSystemObject');
}

function restartWebApp(appPath)
{
    appPath = fso.GetAbsolutePathName(appPath);
    var filePath = fso.BuildPath(appPath, "App_offline.htm");

    var file = fso.CreateTextFile(filePath, true);
    file.WriteLine("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
    file.WriteLine("<html><body><h3>La aplicaci&oacute;n est&aacute; moment&aacute;neamente suspendida</h3>Reintente en unos minutos</body></html>");
    file.Close();
    WScript.StdOut.WriteLine("Pasando la aplicacion "+ appPath +" a modo OFFLINE");

    WScript.Sleep(500);
    WScript.StdOut.WriteLine("Reestableciendo la aplicacion web");
    fso.DeleteFile(filePath);
}
