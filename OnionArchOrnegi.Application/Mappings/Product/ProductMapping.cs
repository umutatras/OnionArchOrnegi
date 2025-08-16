using OnionArchOrnegi.Application.Product.Commands.Add;
using OnionArchOrnegi.Application.Product.Commands.Update;
using OnionArchOrnegi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchOrnegi.Application.Mappings.Product;

public static class ProductMapping
{
    public static OnionArchOrnegi.Domain.Entities.Product ToEntity(this ProductAddCommand dto) =>
        new OnionArchOrnegi.Domain.Entities.Product
        {
            Name = dto.Name,
            Price = dto.Price,
        };

    public static OnionArchOrnegi.Domain.Entities.Product ToEntity(this ProductUpdateCommand dto, OnionArchOrnegi.Domain.Entities.Product existing)
    {
        existing.Name = dto.Name;
        existing.Price = dto.Price;
        return existing;
    }

    //public static ProductListDto ToListDto(this Product entity) =>
    //    new ProductListDto
    //    {
    //        Id = entity.Id,
    //        Name = entity.Name,
    //        Price = entity.Price
    //    };

    //public static ProductGetByIdDto ToGetByIdDto(this Product entity) =>
    //    new ProductGetByIdDto
    //    {
    //        Id = entity.Id,
    //        Name = entity.Name,
    //        Price = entity.Price
    //    };
}