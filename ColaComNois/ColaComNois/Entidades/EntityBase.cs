using System;
using System.ComponentModel.DataAnnotations;

namespace ColaComNois.Entidades
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }

    public class EnumExtensions
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}