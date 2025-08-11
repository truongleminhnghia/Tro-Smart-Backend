using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TroSmart.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initCreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    address_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    address_details = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ward = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    province = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    country = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    location_latitude = table.Column<double>(type: "float", nullable: true),
                    location_longitude = table.Column<double>(type: "float", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.address_id);
                });

            migrationBuilder.CreateTable(
                name: "conversations",
                columns: table => new
                {
                    conversation_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conversations", x => x.conversation_id);
                });

            migrationBuilder.CreateTable(
                name: "packages",
                columns: table => new
                {
                    package_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packages", x => x.package_id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    role_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    name = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "vouchers",
                columns: table => new
                {
                    voucher_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vouchers", x => x.voucher_id);
                });

            migrationBuilder.CreateTable(
                name: "properties",
                columns: table => new
                {
                    property_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    address_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_properties", x => x.property_id);
                    table.ForeignKey(
                        name: "FK_properties_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "addresses",
                        principalColumn: "address_id");
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    role_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConversationMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.account_id);
                    table.ForeignKey(
                        name: "FK_accounts_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "role_id");
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    image_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    url = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    property_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.image_id);
                    table.ForeignKey(
                        name: "FK_images_properties_property_id",
                        column: x => x.property_id,
                        principalTable: "properties",
                        principalColumn: "property_id");
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    booking_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    property_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    person_booking_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    person_scheduled_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.booking_id);
                    table.ForeignKey(
                        name: "FK_bookings_person_booking",
                        column: x => x.person_booking_id,
                        principalTable: "accounts",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_bookings_person_scheduled",
                        column: x => x.person_scheduled_id,
                        principalTable: "accounts",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_bookings_properties_property_id",
                        column: x => x.property_id,
                        principalTable: "properties",
                        principalColumn: "property_id");
                });

            migrationBuilder.CreateTable(
                name: "conversation_members",
                columns: table => new
                {
                    conversation_member_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    conversation_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conversation_members", x => x.conversation_member_id);
                    table.ForeignKey(
                        name: "FK_conversation_members_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_conversation_members_conversations_conversation_id",
                        column: x => x.conversation_id,
                        principalTable: "conversations",
                        principalColumn: "conversation_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK_customers_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "account_id");
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    employee_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_employees_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "account_id");
                });

            migrationBuilder.CreateTable(
                name: "listings",
                columns: table => new
                {
                    listing_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    property_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    post_by_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    approved_by_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    contact_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listings", x => x.listing_id);
                    table.ForeignKey(
                        name: "FK_listings_accounts_approved_by_id",
                        column: x => x.approved_by_id,
                        principalTable: "accounts",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_listings_accounts_post_by_id",
                        column: x => x.post_by_id,
                        principalTable: "accounts",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_listings_properties_property_id",
                        column: x => x.property_id,
                        principalTable: "properties",
                        principalColumn: "property_id");
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    message_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    conversation_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sender_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.message_id);
                    table.ForeignKey(
                        name: "FK_messages_accounts_sender_id",
                        column: x => x.sender_id,
                        principalTable: "accounts",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_messages_conversations_conversation_id",
                        column: x => x.conversation_id,
                        principalTable: "conversations",
                        principalColumn: "conversation_id");
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    review_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    reviewer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    property_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_reviews_accounts_reviewer_id",
                        column: x => x.reviewer_id,
                        principalTable: "accounts",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_reviews_properties_property_id",
                        column: x => x.property_id,
                        principalTable: "properties",
                        principalColumn: "property_id");
                });

            migrationBuilder.CreateTable(
                name: "VoucherUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoucherUsers_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoucherUsers_vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "vouchers",
                        principalColumn: "voucher_id");
                });

            migrationBuilder.CreateTable(
                name: "attentions",
                columns: table => new
                {
                    attention_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    listing_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    property_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attentions", x => x.attention_id);
                    table.ForeignKey(
                        name: "FK_attentions_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_attentions_listings_listing_id",
                        column: x => x.listing_id,
                        principalTable: "listings",
                        principalColumn: "listing_id");
                    table.ForeignKey(
                        name: "FK_attentions_properties_property_id",
                        column: x => x.property_id,
                        principalTable: "properties",
                        principalColumn: "property_id");
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    contact_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    listing_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.contact_id);
                    table.ForeignKey(
                        name: "FK_contacts_listings_listing_id",
                        column: x => x.listing_id,
                        principalTable: "listings",
                        principalColumn: "listing_id");
                });

            migrationBuilder.CreateTable(
                name: "histories",
                columns: table => new
                {
                    history_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    property_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    listing_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_histories", x => x.history_id);
                    table.ForeignKey(
                        name: "FK_histories_listings_listing_id",
                        column: x => x.listing_id,
                        principalTable: "listings",
                        principalColumn: "listing_id");
                    table.ForeignKey(
                        name: "FK_histories_properties_property_id",
                        column: x => x.property_id,
                        principalTable: "properties",
                        principalColumn: "property_id");
                });

            migrationBuilder.CreateTable(
                name: "subscriptions",
                columns: table => new
                {
                    subscription_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    listing_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    package_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscriptions", x => x.subscription_id);
                    table.ForeignKey(
                        name: "FK_subscriptions_listings_listing_id",
                        column: x => x.listing_id,
                        principalTable: "listings",
                        principalColumn: "listing_id");
                    table.ForeignKey(
                        name: "FK_subscriptions_packages_package_id",
                        column: x => x.package_id,
                        principalTable: "packages",
                        principalColumn: "package_id");
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    transaction_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    subscription_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.transaction_id);
                    table.ForeignKey(
                        name: "FK_transactions_subscriptions_subscription_id",
                        column: x => x.subscription_id,
                        principalTable: "subscriptions",
                        principalColumn: "subscription_id");
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    payment_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    transaction_id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_payments_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "FK_payments_transactions_transaction_id",
                        column: x => x.transaction_id,
                        principalTable: "transactions",
                        principalColumn: "transaction_id");
                });

            migrationBuilder.CreateTable(
                name: "voucher_transactions",
                columns: table => new
                {
                    voucher_transaction_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voucher_transactions", x => x.voucher_transaction_id);
                    table.ForeignKey(
                        name: "FK_voucher_transactions_transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "transactions",
                        principalColumn: "transaction_id");
                    table.ForeignKey(
                        name: "FK_voucher_transactions_vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "vouchers",
                        principalColumn: "voucher_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_role_id",
                table: "accounts",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_attentions_account_id",
                table: "attentions",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_attentions_listing_id",
                table: "attentions",
                column: "listing_id");

            migrationBuilder.CreateIndex(
                name: "IX_attentions_property_id",
                table: "attentions",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_person_booking_id",
                table: "bookings",
                column: "person_booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_person_scheduled_id",
                table: "bookings",
                column: "person_scheduled_id");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_property_id",
                table: "bookings",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_listing_id",
                table: "contacts",
                column: "listing_id");

            migrationBuilder.CreateIndex(
                name: "IX_conversation_members_AccountId",
                table: "conversation_members",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_conversation_members_conversation_id",
                table: "conversation_members",
                column: "conversation_id");

            migrationBuilder.CreateIndex(
                name: "IX_customers_AccountId",
                table: "customers",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_AccountId",
                table: "employees",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_histories_listing_id",
                table: "histories",
                column: "listing_id");

            migrationBuilder.CreateIndex(
                name: "IX_histories_property_id",
                table: "histories",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_images_property_id",
                table: "images",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_listings_approved_by_id",
                table: "listings",
                column: "approved_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_listings_post_by_id",
                table: "listings",
                column: "post_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_listings_property_id",
                table: "listings",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_conversation_id",
                table: "messages",
                column: "conversation_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_sender_id",
                table: "messages",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_account_id",
                table: "payments",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_transaction_id",
                table: "payments",
                column: "transaction_id");

            migrationBuilder.CreateIndex(
                name: "IX_properties_address_id",
                table: "properties",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_property_id",
                table: "reviews",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_reviewer_id",
                table: "reviews",
                column: "reviewer_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_listing_id",
                table: "subscriptions",
                column: "listing_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_package_id",
                table: "subscriptions",
                column: "package_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_subscription_id",
                table: "transactions",
                column: "subscription_id");

            migrationBuilder.CreateIndex(
                name: "IX_voucher_transactions_TransactionId",
                table: "voucher_transactions",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_voucher_transactions_VoucherId",
                table: "voucher_transactions",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherUsers_AccountId",
                table: "VoucherUsers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherUsers_VoucherId",
                table: "VoucherUsers",
                column: "VoucherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attentions");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "conversation_members");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "histories");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "voucher_transactions");

            migrationBuilder.DropTable(
                name: "VoucherUsers");

            migrationBuilder.DropTable(
                name: "conversations");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "vouchers");

            migrationBuilder.DropTable(
                name: "subscriptions");

            migrationBuilder.DropTable(
                name: "listings");

            migrationBuilder.DropTable(
                name: "packages");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "properties");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "addresses");
        }
    }
}
