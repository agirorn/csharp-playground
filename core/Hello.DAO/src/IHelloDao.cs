using System.Threading.Tasks;
using Hello.Model;

public interface IHelloDao
{
    Task<Hello?> GetHelloAsync();
}
