using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using publisherApi.MediatR.Queries;
using publisherApi;

using System.Threading;
using System.Threading.Tasks;
namespace publisherApi.MediatR.Handlers
{


    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IEnumerable<User>>
    {

        private static readonly string[] Teams = new[]
        {
            "Bulent", "Nuray", "Sinem", "Tamer", "Yahya"
        };

        public async Task<IEnumerable<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {

            var rng = new Random();
            var result = Enumerable.Range(0, 4).Select(index => new User
            {
                Name = Teams[index],
                Date = DateTime.Now.AddDays(index),
                Old = rng.Next(20, 55),

            });
                

            return await Task.FromResult(result);
        }
    }
}