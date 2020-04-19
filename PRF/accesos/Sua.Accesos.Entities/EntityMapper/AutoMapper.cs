using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using System.Collections.Generic;
using AutoMapper;

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Entities
{
    public static class AutoMapper
    {
        private static IMapper _mapper = new MapperConfiguration(cfg =>
        {

            cfg.CreateMap<ACC_dAplicaciones, Aplicacion>()
                .ForMember(dest => dest.Acciones, opt =>
                   opt.MapFrom(src => src.ACC_dAcciones))
                .ForMember(dest => dest.Estado, opt =>
                    opt.MapFrom(src => src.ACC_sEstados.id.ToString()))
                .ForPath(dest => dest.Menus, opts => opts.Ignore())
                .ForPath(dest => dest.Perfiles, opts => opts.Ignore())
                .ForMember(dest => dest.esPocket, opt =>
                    opt.MapFrom(src => src.esPocket == "S"));
            cfg.CreateMap<ACC_dMenu, Menu>();
            cfg.CreateMap<ACC_dAcciones, Accion>() 
                .ForMember(dest => dest.Aplicacion, opt =>
                   opt.MapFrom(src => src.ACC_dAplicaciones))
                .ForMember(dest => dest.Estado, opt =>
                   opt.MapFrom(src => src.ACC_sEstados.id.ToString()));
            cfg.CreateMap<ACC_dPerfiles, Perfil>()
               .ForMember(dest => dest.Region, opt =>
                   opt.MapFrom(src => src.ACC_sRegiones))
               .ForMember(dest => dest.Aplicacion, opt =>
                   opt.MapFrom(src => src.ACC_dAplicaciones))
               .ForPath(dest => dest.Acciones, opts => opts.Ignore())
               .ForMember(dest => dest.Estado, opt =>
                   opt.MapFrom(src => src.ACC_sEstados.id.ToString()));
            cfg.CreateMap<ACC_dUsuarios, Usuario>()
                .ForMember(dest => dest.Estado, opt =>
                   opt.MapFrom(src => src.idEstado.ToString()));
            cfg.CreateMap<ACC_rdPerfil_dAcciones, Perfil_Accion>()
                .ForMember(dest => dest.Perfil, opt =>
                    opt.MapFrom(src => src.ACC_dPerfiles))
                .ForMember(dest => dest.Accion, opt =>
                    opt.MapFrom(src => src.ACC_dAcciones));
                
            //cfg.CreateMap<ACC_sEstados, Estado>();
            cfg.CreateMap<ACC_sRegiones, Region>();
            cfg.CreateMap<Usuario, ACC_dUsuarios>()
                .ForMember(dest => dest.idEstado, opt => 
                    opt.MapFrom(src => src.Estado.ToString()));        
            cfg.CreateMap<Perfil, ACC_dPerfiles>()
                .ForMember(dest => dest.ACC_sRegiones, opt =>
                    opt.MapFrom(src => src.Region))
                .ForMember(dest => dest.ACC_dAplicaciones, opt =>
                    opt.MapFrom(src => src.Aplicacion));


            cfg.CreateMap<ACC_rdMenu_dAcciones, Menu_Acciones>()
                .ForMember(dest => dest.Accion, opt =>
                    opt.MapFrom(src => src.ACC_dAcciones))
                .ForMember(dest => dest.Aplicacion, opt =>
                    opt.MapFrom(src => src.ACC_dAplicaciones))
                .ForMember(dest => dest.Menu, opt =>
                    opt.MapFrom(src => src.ACC_dMenu)); 

            cfg.CreateMap<ACC_rdUsuarios_dPerfiles_dAcciones, Usuario_Perfil_Acciones>()
                .ForMember(dest => dest.Perfil_Accion, opt =>
                    opt.MapFrom(src => src.ACC_rdPerfil_dAcciones));
            cfg.CreateMap<ACC_sEstados, Estado>();
            cfg.CreateMap<ACC_sRegiones, Region>();
            cfg.CreateMap<Usuario_Perfil_Acciones, ACC_rdUsuarios_dPerfiles_dAcciones>();

        }).CreateMapper();

        #region ToModel
        public static Usuario ToModel(this ACC_dUsuarios entity)
        {
            return _mapper.Map<ACC_dUsuarios, Usuario>(entity);
        }
        public static Usuario_Perfil_Acciones ToModel(this ACC_rdUsuarios_dPerfiles_dAcciones entity)
        {
            return _mapper.Map<ACC_rdUsuarios_dPerfiles_dAcciones, Usuario_Perfil_Acciones>(entity);
        }
        public static List<Perfil_Accion> ToModel(this List<ACC_rdPerfil_dAcciones> entity)
        {
            return _mapper.Map<List<ACC_rdPerfil_dAcciones>, List<Perfil_Accion>>(entity);
        }
        public static Perfil_Accion ToModel(this ACC_rdPerfil_dAcciones entity)
        {
            return _mapper.Map<ACC_rdPerfil_dAcciones, Perfil_Accion>(entity);
        }
        public static List<Perfil> ToModel(this List<ACC_dPerfiles> entity)
        {
            return _mapper.Map<List<ACC_dPerfiles>, List<Perfil>>(entity);
        }
        public static Perfil ToModel(this ACC_dPerfiles entity)
        {
            return _mapper.Map<ACC_dPerfiles, Perfil>(entity);
        }

        public static List<Aplicacion> ToModel(this List<ACC_dAplicaciones> entity)
        {
            return _mapper.Map<List<ACC_dAplicaciones>, List<Aplicacion>>(entity);
        }

        public static Aplicacion ToModel(this ACC_dAplicaciones entity)
        {
            return _mapper.Map<ACC_dAplicaciones, Aplicacion>(entity);
        }

        public static List<Accion> ToModel(this List<ACC_dAcciones> entity)
        {
            return _mapper.Map<List<ACC_dAcciones>, List<Accion>>(entity);
        }

        public static Accion ToModel(this ACC_dAcciones entity)
        {
            return _mapper.Map <ACC_dAcciones, Accion>(entity);
        }

        public static Menu ToModel(this ACC_dMenu entity)
        {
            return _mapper.Map<ACC_dMenu, Menu>(entity);
        }

        public static List<Menu> ToModel(this List<ACC_dMenu> entity)
        {
            return _mapper.Map<List<ACC_dMenu>, List<Menu>>(entity);
        }

        public static List<Region> ToModel(this List<ACC_sRegiones> entity)
        {
            return _mapper.Map<List<ACC_sRegiones>, List<Region>>(entity);
        }

        public static Region ToModel(this ACC_sRegiones entity)
        {
            return _mapper.Map<ACC_sRegiones, Region>(entity);
        }
        #endregion

        #region ToEntity
        public static ACC_rdPerfil_dAcciones ToEntity(this Perfil_Accion entity)
        {
            return _mapper.Map<Perfil_Accion, ACC_rdPerfil_dAcciones>(entity);
        }
        public static ACC_rdUsuarios_dPerfiles_dAcciones ToEntity(this Usuario_Perfil_Acciones entity)
        {
            return _mapper.Map<Usuario_Perfil_Acciones, ACC_rdUsuarios_dPerfiles_dAcciones>(entity);
        }
        public static List<ACC_dUsuarios> ToEntity(this List<Usuario> entity)
        {
            return _mapper.Map<List<Usuario>, List<ACC_dUsuarios>>(entity);
        }
        public static ACC_dUsuarios ToEntity(this Usuario entity)
        {
            return _mapper.Map<Usuario, ACC_dUsuarios>(entity);
        }      
        public static ACC_dPerfiles ToEntity(this Perfil entity)
        {
            return _mapper.Map<Perfil, ACC_dPerfiles>(entity);
        }
        #endregion
    }
}
