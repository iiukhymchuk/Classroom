using ApiClassModel = Classroom.Common.Models.Api.ClassModel;
using ApiClassInputModel = Classroom.Common.Models.Api.ClassInputModel;
using ServicesClassModel = Classroom.Common.Models.Services.ClassModel;
using ServicesClassInputModel = Classroom.Common.Models.Services.ClassInputModel;
using PersistenceClassModel = Classroom.Common.Models.Persistence.ClassModel;
using PersistenceClassInputModel = Classroom.Common.Models.Persistence.ClassInputModel;
using System;

namespace Classroom.Common
{
    public static class Mapper
    {
        public static PersistenceClassModel ToPersistenceModel(this ServicesClassModel model)
        {
            if (model is null)
                return null;
            return new PersistenceClassModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                ModifiedUTC = model.ModifiedUTC,
                CreatedUTC = model.CreatedUTC
            };
        }

        public static ServicesClassModel ToServicesModel(this PersistenceClassModel model)
        {
            if (model is null)
                return null;
            return new ServicesClassModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                ModifiedUTC = model.ModifiedUTC,
                CreatedUTC = model.CreatedUTC
            };
        }

        public static ApiClassModel ToApiModel(this ServicesClassModel model)
        {
            if (model is null)
                return null;
            return new ApiClassModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Created = model.CreatedUTC
            };
        }

        public static ServicesClassInputModel ToServicesModel(this ApiClassInputModel model)
        {
            if (model is null)
                return null;
            return new ServicesClassInputModel
            {
                Name = model.Name,
                Description = model.Description
            };
        }

        public static PersistenceClassInputModel ToPersistenceModel(this ServicesClassInputModel model, DateTime time)
        {
            if (model is null)
                return null;

            return new PersistenceClassInputModel
            {
                Name = model.Name,
                Description = model.Description,
                ModifiedUTC = time
            };
        }
    }
}