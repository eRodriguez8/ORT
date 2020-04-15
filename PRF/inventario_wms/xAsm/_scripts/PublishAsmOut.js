// Script de post-build de un proyecto
// Copia los assemblies producidos por el proyecto a la carpeta xAsmOut en el proyecto xAsm
//
// USO - asignar en el evento de post-build de CADA proyecto, ej.
//         cscript ..\..\..\xAsm\_scripts\PublishAsmOut.js 
//
// Utilizarlo solamente en los assemblies que se comparten con otras soluciones,
// por ej: FlexCore*, SgcLib*, etc.
// No utilizarlo para los assemblies que se comparten sólo dentro de la solucion (ej. Biz)
//
// Autor: José Marcenaro - Tercer Planeta - josem@tercerplaneta.com
// Fecha: 2008.05.15

var fso;                 // File System Object
var solutionPath;        // path a la carpeta raiz de la solucion, sin \ final

prepare();

copyFiles(solutionPath+"\\xAsmOut\\");

function copyFiles(targetFolder) 
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
            // WScript.StdOut.WriteLine("\t"+fileName);
            
                if (fso.FileExists(targetFolder+fileName)) {
                var f = fso.GetFile(targetFolder+fileName);
                if (f.Attributes & 1 == 1){
                    // Quitar el atributo de solo lectura
                    f.Attributes = f.Attributes - 1;
                }
            }
            
            fso.CopyFile(filePath,targetFolder+fileName,true);
        }
    }
    catch( e ) {
        WScript.StdOut.WriteLine("Unable to copy files to "+targetFolder+"\n\n"+e.message);
        WScript.Quit(-1);
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
    solutionPath = fso.GetParentFolderName( fso.GetParentFolderName( fso.GetParentFolderName( WScript.ScriptFullName)));

    // extraPath = WScript.Arguments.Length==0? "": WScript.Arguments(0);
}

