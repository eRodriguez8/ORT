// Script de invocación automática desde Cruise Control .NET
// (en el build completo de SgcNet2)
// Vacía la carpeta Services de cada publisher, antes de realizar el build general
// El working directory de ejecucion debe ser la carpeta xAsm\_scripts
// (donde reside este script, de modo de que tambien pueda ejecutarse desde la IDE de VS)
//
// Autor: José Marcenaro - Tercer Planeta - josem@tercerplaneta.com
// Fecha: 2008.04.23

var fso;                 // File System Object
var type;                // "Ext" o "Int"

prepare();
procesar("IntK");
procesar("ExtK");
procesar("ExtU");

if (WScript.Arguments.Length <1 || WScript.Arguments(0) != "/quiet") {
    WScript.StdOut.Write("\nPress ENTER to end...");
    WScript.StdIn.ReadLine();   
    }
    
function procesar(publisher) 
{
   var publisherPath = "..\\..\\PublisherSln\\GenericPublisher" + publisher;
   deleteFiles( publisherPath+"\\Services\\");
}

function deleteFiles(targetFolder) 
{
    var folder = fso.GetFolder(targetFolder);
    var files = new Enumerator(folder.files);
    WScript.StdOut.WriteLine("\nDeleting from "+targetFolder+":");
    try {
        for (; !files.atEnd(); files.moveNext()) 
        {
            var filePath = files.item() + "";
            var fileName = fso.GetFileName(filePath);
            WScript.StdOut.Write(fileName+",");
            fso.DeleteFile(filePath);
        }
    }
    catch( e ) {
        WScript.Echo("Unable to delete files from "+targetFolder+"\n\n"+e.message);
    }
}

function prepare() 
{
    fso = new ActiveXObject('Scripting.FileSystemObject');
}