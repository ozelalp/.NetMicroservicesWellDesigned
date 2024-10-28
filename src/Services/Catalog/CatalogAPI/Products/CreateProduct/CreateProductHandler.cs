﻿using BuildingBlocks.CQRS;
using CatalogAPI.Models;

namespace CatalogAPI.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) 
        : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = command.Name,
                Description = command.Description,
                Category = command.Category,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            return Task.FromResult(new CreateProductResult(Guid.NewGuid()));
        }
    }
}
