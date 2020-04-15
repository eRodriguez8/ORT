import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HelperService {

  constructor() { }

  public downloadFile(data: string, fileName: string) {
      let dataArray = this.s2ab(atob(data));
      try {
          let blob = new Blob([dataArray], {type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64'});
          // let blob = new Blob([new Uint8Array(data)]);
          try {
              // let blob = new Blob([new Uint8Array(data)]);
              let blob = new Blob([dataArray], {type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64'});
              window.navigator.msSaveOrOpenBlob(blob, this.cleanUpSpecialChars(fileName) + ".xlsx");
          }
          catch (e) {
              var url = window.URL.createObjectURL(blob);
              var link = document.createElement("a");
              link.setAttribute("href", url);
              link.setAttribute("download", this.cleanUpSpecialChars(fileName) + ".xlsx");
              link.style.display = "none";
              document.body.appendChild(link);
              link.click();
              document.body.removeChild(link);
          }

      }
      catch (e) {
          alert('Error al exportar excel');
          return;
      }
  }

  cleanUpSpecialChars(str) {
      str = str.replace(/[ÀÁÂÃÄÅ]/g, "A");
      str = str.replace(/[àáâãäå]/g, "a");
      str = str.replace(/[éëèê]/g, "e");
      str = str.replace(/[ÈÉÊË]/g, "E");
      str = str.replace(/[Î]/g, "I");
      str = str.replace(/[íì]/g, "i");
      str = str.replace(/[Ô]/g, "O");
      str = str.replace(/[óòôö]/g, "o");
      str = str.replace(/[Ù]/g, "U");
      str = str.replace(/[úùüû]/g, "u");
      str = str.replace(/[Ç]/g, "C")
      //.... all the rest
      return str.replace(/[^a-z0-9]/gi, ' '); // final clean up
  }

  OnlyNumber(str) {
      return str.replace(/[^0-9]/gi, '');
  }

  s2ab(s: string) {
    var buf = new ArrayBuffer(s.length);
    var view = new Uint8Array(buf);
    for (var i=0; i!=s.length; ++i) { view[i] = s.charCodeAt(i) & 0xFF; }
    return buf;
  }
}
