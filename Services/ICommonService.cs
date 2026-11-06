using System;
using Backend.DTOs;
namespace Backend.Services;
public interface ICommonService<T, TI, TU>
{
    Task<IEnumerable<T>> Get();
    Task<T> GetById(int id);
    Task<T> Add(TI beerInsert);
    Task<T> Update(int id, TU beerUpdateDto);
    Task<T> Delete(int id);
}