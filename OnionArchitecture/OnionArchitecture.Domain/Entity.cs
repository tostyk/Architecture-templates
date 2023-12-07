﻿namespace OnionArchitecture.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity(Guid id)
        {
            Id = id;
        }

        protected Entity()
        {
        }
    }
}
