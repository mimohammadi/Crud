﻿namespace Crud.Domain.Models
{
    public class BaseEntity : SoftDelete
    {
        public long Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? LastUpdateOn { get; set; }

        public virtual void Delete()
        {
            IsDeleted = true;
            DeletedOn = DateTime.Now;
        }
    }

    public class SoftDelete
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedOn { get; set; }
    }
}
