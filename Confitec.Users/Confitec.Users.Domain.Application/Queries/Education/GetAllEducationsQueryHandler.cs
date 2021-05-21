using Confitec.Users.Domain.Application.Configurations;
using Confitec.Users.Domain.Application.Core;
using Confitec.Users.Infrastructure.Data.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Users.Domain.Application.Queries.Education
{
    class GetAllEducationsQueryHandler : BaseHandler, IRequestHandler<GetAllEducationsQuery, Response>
    {
        private readonly IEducationRepository _educationRepository;

        public GetAllEducationsQueryHandler(IEducationRepository EducationRepository,
                                      IResponseService responseService) : base(responseService)
        {
            _educationRepository = EducationRepository;
        }

        public async Task<Response> Handle(GetAllEducationsQuery request, CancellationToken cancellationToken)
        {
            return await SafeExecuteAsync(async () =>
            {
                var educations = await _educationRepository.GetAllAsync();

                return _responseService.GetSuccessResponse(educations);
            });
        }
    }
}
