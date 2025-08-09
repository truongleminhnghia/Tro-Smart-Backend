using Microsoft.Extensions.DependencyInjection;
using TroSmart.Domain.Interfaces;
using TroSmart.Domain.Interfaces.Base;
using TroSmart.Infrastructure.Persistence;
using TroSmart.Infrastructure.Persistence.Base;
using TroSmart.Infrastructure.Persistence.Repositories;

namespace TroSmart.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            // base
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Repository
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAttentionRepository, AttentionRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IConversationMemberRepository, ConversationMemberRepository>();
            services.AddScoped<IConversationRepository, ConversationRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<EmployeeRepository, EmployeeRepository>();
            services.AddScoped<IHistoryRepository, HistoryRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IListingRepository, ListingRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<ITransactionRepository, TranscationRepository>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<IVoucherTranscationRepository, VoucherTranscationRepository>();
            services.AddScoped<IVoucherUserRepository, VoucherUserRepository>();
            return services;
        }
    }
}