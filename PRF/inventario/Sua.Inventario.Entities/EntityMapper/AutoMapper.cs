using Corp.Cencosud.Supermercados.Sua_Inventario.Dal;
using System.Collections.Generic;
using AutoMapper;
using Corp.Cencosud.Supermercados.Sua.Inventario.Dal;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Entities
{
    public static class AutoMapper
    {
        private static IMapper _mapper = new MapperConfiguration(cfg =>
        {

            cfg.CreateMap<INV_dPosiciones, Posicion>();
            cfg.CreateMap<INV_dDocumentos, Documento>()
            .ForMember(dest => dest.posiciones, opts => opts.MapFrom(src => src.INV_dPosiciones))
            .ForMember(dest => dest.estado, opt => opt.MapFrom(src => (int)src.Estado))
            .ForMember(dest => dest.fase, opt => opt.MapFrom(src => (int)src.Fase));
            cfg.CreateMap<Posicion, INV_dPosiciones>();
            cfg.CreateMap<Documento, INV_dDocumentos>()
            .ForMember(dest => dest.INV_dPosiciones, opts => opts.MapFrom(src => src.posiciones))
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => (int)src.estado))
            .ForMember(dest => dest.Fase, opt => opt.MapFrom(src => (int)src.fase));
            cfg.CreateMap<Inventario, INV_dInventario>()
            .ForMember(dest => dest.INV_dDocumentos, opts => opts.MapFrom(src => src.documento))
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => (int)src.estado))
            .ForPath(dest => dest.INV_dDocumentos, opts => opts.Ignore());
            cfg.CreateMap<INV_dInventario, Inventario>()
            .ForMember(dest => dest.documento, opts => opts.MapFrom(src => src.INV_dDocumentos))
            .ForMember(dest => dest.acciones, opt => opt.MapFrom(src => new List<string>()))
            .ForMember(dest => dest.estado, opt => opt.MapFrom(src => (Estado)src.Estado));
            cfg.CreateMap<INV_dCCsActivos, CC>();
            cfg.CreateMap<CC, INV_dCCsActivos>()
            .ForPath(dest => dest.usuario, opts => opts.Ignore())
            .ForPath(dest => dest.ts, opts => opts.Ignore());

        }).CreateMapper();

        #region ToModel
        public static Posicion ToModel(this INV_dPosiciones entity)
        {
            return _mapper.Map<INV_dPosiciones, Posicion>(entity);
        }

        public static Documento ToModel(this INV_dDocumentos entity)
        {
            return _mapper.Map<INV_dDocumentos, Documento>(entity);
        }

        public static Inventario ToModel(this INV_dInventario entity)
        {
            return _mapper.Map<INV_dInventario, Inventario>(entity);
        }
        public static List<Inventario> ToModel(this List<INV_dInventario> entity)
        {
            return _mapper.Map<List<INV_dInventario>, List<Inventario>>(entity);
        }
        public static CC ToModel(this INV_dCCsActivos entity)
        {
            return _mapper.Map<INV_dCCsActivos, CC>(entity);
        }
        public static List<CC> ToModel(this List<INV_dCCsActivos> entity)
        {
            return _mapper.Map<List<INV_dCCsActivos>, List<CC>>(entity);
        }

        public static List<Documento> ToModel(this List<INV_dDocumentos> entity)
        {
            return _mapper.Map<List<INV_dDocumentos>, List<Documento>>(entity);
        }
        public static List<Posicion> ToModel(this List<INV_dPosiciones> entity)
        {
            return _mapper.Map<List<INV_dPosiciones>, List<Posicion>>(entity);
        }
        #endregion

        #region ToEntity
        public static INV_dPosiciones ToEntity(this Posicion entity)
        {
            return _mapper.Map<Posicion, INV_dPosiciones>(entity);
        }
        public static List<INV_dPosiciones> ToEntity(this List<Posicion> entity)
        {
            return _mapper.Map<List<Posicion>, List<INV_dPosiciones>>(entity);
        }
        public static INV_dCCsActivos ToEntity(this CC entity)
        {
            return _mapper.Map<CC, INV_dCCsActivos>(entity);
        }
        public static List<INV_dCCsActivos> ToEntity(this List<CC> entity)
        {
            return _mapper.Map<List<CC>, List<INV_dCCsActivos>>(entity);
        }
        public static INV_dInventario ToEntity(this Inventario entity)
        {
            return _mapper.Map<Inventario, INV_dInventario>(entity);
        }
        public static List<INV_dInventario> ToEntity(this List<Inventario> entity)
        {
            return _mapper.Map<List<Inventario>, List<INV_dInventario>>(entity);
        }
        
        public static INV_dDocumentos ToEntity(this Documento entity)
        {
            return _mapper.Map<Documento, INV_dDocumentos>(entity);
        }
        public static List<INV_dDocumentos> ToEntity(this List<Documento> entity)
        {
            return _mapper.Map<List<Documento>, List<INV_dDocumentos>>(entity);
        }

        #endregion
    }
}
