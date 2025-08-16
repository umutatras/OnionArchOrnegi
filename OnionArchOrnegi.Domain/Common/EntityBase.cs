﻿namespace OnionArchOrnegi.Domain.Common;
public abstract class EntityBase<TKey> : IEntity<TKey>, ICreatedByEntity, IModifiedByEntity
{
    public virtual TKey Id { get; set; }
    public virtual DateTimeOffset? ModifiedOn { get; set; }
    public virtual int? ModifiedByUserId { get; set; }
    public virtual DateTimeOffset CreatedOn { get; set; }
    public virtual int? CreatedByUserId { get; set; }
}