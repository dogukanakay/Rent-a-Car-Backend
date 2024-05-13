using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.MappingProfiles;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Tokens;
using Core.Utilities.Security.Tokens.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<ModelManager>().As<IModelService>().SingleInstance();
            builder.RegisterType<EfModelDal>().As<IModelDal>().SingleInstance();

            builder.RegisterType<CarClassManager>().As<ICarClassService>().SingleInstance();
            builder.RegisterType<EfCarClassDal>().As<ICarClassDal>().SingleInstance();

            builder.RegisterType<FuelTypeManager>().As<IFuelTypeService>().SingleInstance();
            builder.RegisterType<EfFuelTypeDal>().As<IFuelTypeDal>().SingleInstance();

            builder.RegisterType<GearTypeManager>().As<IGearTypeService>().SingleInstance();
            builder.RegisterType<EfGearTypeDal>().As<IGearTypeDal>().SingleInstance();

            builder.RegisterType<PaymentCardManager>().As<IPaymentCardService>().SingleInstance();
            builder.RegisterType<EfPaymentCardDal>().As<IPaymentCardDal>().SingleInstance();

            builder.RegisterType<PaymentManager>().As<IPaymentService>().SingleInstance();
            builder.RegisterType<EfPaymentDal>().As<IPaymentDal>().SingleInstance();

            builder.RegisterType<RentalLocationManager>().As<IRentalLocationService>().SingleInstance();
            builder.RegisterType<EfRentalLocationDal>().As<IRentalLocationDal>().SingleInstance();

            builder.RegisterType<CarImagesManager>().As<ICarImagesService>().SingleInstance();
            builder.RegisterType<EfCarImagesDal>().As<ICarImagesDal>().SingleInstance();
            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();



            
            builder.Register(
                c => new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MapperProfile());
                }))
                .AsSelf()
                .SingleInstance();

            builder.Register(
                c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();

            



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();



        }


    }
}
