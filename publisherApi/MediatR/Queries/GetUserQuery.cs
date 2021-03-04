using MediatR;
using System.Collections.Generic;
using publisherApi;
namespace publisherApi.MediatR.Queries
{

    public class GetUserQuery : IRequest<IEnumerable<User>>
    {


    }
}
