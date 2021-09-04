using SistemaBancarioAPI.Interfaces;
using System;

namespace SistemaBancarioAPI.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}