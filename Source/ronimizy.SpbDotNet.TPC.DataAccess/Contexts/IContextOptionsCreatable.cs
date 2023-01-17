using Microsoft.EntityFrameworkCore;

namespace ronimizy.SpbDotNet.TPC.DataAccess.Contexts;

public interface IContextOptionsCreatable<T> where T : DatabaseContextBase
{
    static abstract T Create(DbContextOptions<T> options);
}