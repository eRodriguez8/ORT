// Script de pre-build para el proyecto xAsm
// Vacia la carpeta xAsmOut de la solucion a la cual pertenece
//
// USO - se invoca automáticamente como primer tarea del build (o rebuild) del proyecto xAsm
//
// Autor: José Marcenaro - Tercer Planeta - josem@tercerplaneta.com
// Fecha: 2008.05.15

var fso;                 // File System Object
var solutionPath;        // path a la carpeta raiz de la solucion, sin \ final

prepare();

deleteFiles(solutionPath+"\\xAsmOut\\");

function deleteFiles(targetFolder) 
{
    if (!fso.FolderExists(targetFolder))
        return;
    var folder = fso.GetFolder(targetFolder);
    var files = new Enumerator(folder.files);
    WScript.StdOut.WriteLine("\nDeleting from "+targetFolder);
    try {
        for (; !files.atEnd(); files.moveNext()) 
        {
            var filePath = files.item() + "";
            var fileName = fso.GetFileName(filePath);
            // WScript.StdOut.Write(fileName+",");
            fso.DeleteFile(filePath);
        }
    }
    catch( e ) {
        WScript.StdOut.WriteLine("Unable to delete files from "+targetFolder+"\n\n"+e.message);
        WScript.Quit(-1);
    }
}

function prepare() 
{
    fso = new ActiveXObject('Scripting.FileSystemObject');
    solutionPath = fso.GetParentFolderName( fso.GetParentFolderName( fso.GetParentFolderName( WScript.ScriptFullName)));

    // extraPath = WScript.Arguments.Length==0? "": WScript.Arguments(0);
}

