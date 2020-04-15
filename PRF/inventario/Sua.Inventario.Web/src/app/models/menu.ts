export class Menu {
    constructor(
      public id: number,
        public idPrecede: number,
        public nombre: string,
        public tooltip: string,
        public descripcion: string,
        public orden: number,
        public idEstado: string,
        public usuariosMaximos: number,
        public imagen: string,
        public url: string,
        public subMenu: Menu[],
        public clase: string
    ) { }

    // static MOCK: Menu[] = [
    //     new Menu(1, 0, "Administración de Reclamos", "Administración de Reclamos", "", "", "", "ADMReclamos", "", "", [])
    // ];
}
