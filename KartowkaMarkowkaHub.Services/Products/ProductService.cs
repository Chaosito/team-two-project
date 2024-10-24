﻿using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Data.Repositories;
using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using FluentValidation;

namespace KartowkaMarkowkaHub.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IValidator _validator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCache _distributedCache;

        public ProductService(
            IMapper mapper, 
            IValidator validator, 
            IUnitOfWork unitOfWork, 
            IDistributedCache distributedCache)
        {
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
            _distributedCache = distributedCache;
        }

        public async Task<IEnumerable<GetProductDto>> Get(Guid userId)
        {
            IEnumerable<GetProductDto> viewModels = [];
            string key = $"products-for-{userId}";
            string? textProducts = await _distributedCache.GetStringAsync(key);
            if (textProducts != null)
            {
                viewModels = JsonSerializer.Deserialize<IEnumerable<GetProductDto>>(textProducts) ?? [];
            }
            else
            {
                var products = _unitOfWork.ProductRepository
                    .Get(filter: p => p.UserId == userId);
                viewModels = _mapper.Map<IEnumerable<GetProductDto>>(products).ToList();

                textProducts = JsonSerializer.Serialize(viewModels);
                await _distributedCache.SetStringAsync(key, textProducts, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });             
            }            
            return viewModels;
        }

        public async Task<IEnumerable<GetProductDto>> Get()
        {
            IEnumerable<GetProductDto> viewModels = [];
            string key = "products";
            var textProducts = await _distributedCache.GetStringAsync(key);
            if(textProducts != null)
            {
                viewModels = JsonSerializer.Deserialize<IEnumerable<GetProductDto>>(textProducts) ?? [];
            }
            else
            {
                var products = _unitOfWork.ProductRepository.Get();
                viewModels = _mapper.Map<IEnumerable<GetProductDto>>(products).ToList();
                
                textProducts = JsonSerializer.Serialize(viewModels);
                await _distributedCache.SetStringAsync(key, textProducts, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });
                         
            }
            return viewModels;
        }

        public void Create(CreateProductDto productDto, Guid userId)
        {
            var validationContext = new ValidationContext<CreateProductDto>(productDto);
            var errors = _validator.Validate(validationContext).Errors;
            if (errors.Count != 0)
                throw new ValidationException(errors);

            Product product = _mapper.Map<Product>(productDto);

            product.UserId = userId;
            _unitOfWork.ProductRepository.Insert(product);
            _unitOfWork.Save();            
        }        

        public void Update(Guid productId, UpdateProductDto productDto)
        {
            var product = _unitOfWork.ProductRepository.GetByID(productId) 
                ?? throw new ArgumentNullException("Товар не найден в базе данных!");

            var validationContext = new ValidationContext<UpdateProductDto>(productDto);
            var errors = _validator.Validate(validationContext).Errors;
            if (errors.Count != 0)
                throw new ValidationException(errors);

            product = _mapper.Map(productDto, product);
            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.Save();
        }

        public void Remove(Guid productId)
        {
            _unitOfWork.ProductRepository.Delete(productId);
            _unitOfWork.Save();
        }
    }
}