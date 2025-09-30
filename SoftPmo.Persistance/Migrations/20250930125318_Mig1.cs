using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftPmo.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACTIVITY_STATUS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    IsRejected = table.Column<bool>(type: "boolean", nullable: false),
                    RequiresApproval = table.Column<bool>(type: "boolean", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTIVITY_STATUS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ATTENDANCE_EXCEPTION_TYPE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    RequiresApproval = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeductible = table.Column<bool>(type: "boolean", nullable: false),
                    DefaultMinutes = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTENDANCE_EXCEPTION_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ATTENDANCE_RULE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    RequiredMinutes = table.Column<int>(type: "integer", nullable: false),
                    FlexibilityMinutes = table.Column<int>(type: "integer", nullable: false),
                    RequiresBothCheckInOut = table.Column<bool>(type: "boolean", nullable: false),
                    MaxSessionHours = table.Column<int>(type: "integer", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTENDANCE_RULE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CODE_TEMPLATE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    EntityType = table.Column<string>(type: "text", nullable: true),
                    CodeFormat = table.Column<string>(type: "text", nullable: true),
                    Prefix = table.Column<string>(type: "text", nullable: true),
                    UseYear = table.Column<bool>(type: "boolean", nullable: false),
                    SequenceLength = table.Column<int>(type: "integer", nullable: false),
                    StartingNumber = table.Column<int>(type: "integer", nullable: false),
                    CurrentNumber = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CODE_TEMPLATE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_M",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    TaxNumber = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    HasMaintenanceContract = table.Column<bool>(type: "boolean", nullable: false),
                    MonthlyMaintenanceFee = table.Column<decimal>(type: "numeric", nullable: true),
                    MaintenanceStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MaintenanceEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AutoRenewMaintenance = table.Column<bool>(type: "boolean", nullable: false),
                    PrimaryContactName = table.Column<string>(type: "text", nullable: true),
                    PrimaryContactEmail = table.Column<string>(type: "text", nullable: true),
                    TechnicalContactName = table.Column<string>(type: "text", nullable: true),
                    TechnicalContactEmail = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_M", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DASHBOARD_WIDGET",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    WidgetType = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false),
                    ConfigurationJson = table.Column<string>(type: "text", nullable: true),
                    DataSource = table.Column<string>(type: "text", nullable: true),
                    RefreshIntervalSeconds = table.Column<int>(type: "integer", nullable: false),
                    RequiredRole = table.Column<string>(type: "text", nullable: true),
                    IsManagerOnly = table.Column<bool>(type: "boolean", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DASHBOARD_WIDGET", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LOCATION_TYPE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    AllowRemoteWork = table.Column<bool>(type: "boolean", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCATION_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NOTE_PERMISSION_TYPE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    DefaultCanRead = table.Column<bool>(type: "boolean", nullable: false),
                    DefaultCanWrite = table.Column<bool>(type: "boolean", nullable: false),
                    DefaultCanDelete = table.Column<bool>(type: "boolean", nullable: false),
                    DefaultCanShare = table.Column<bool>(type: "boolean", nullable: false),
                    DefaultCanAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTE_PERMISSION_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NOTIFICATION_TYPE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    IsSystemGenerated = table.Column<bool>(type: "boolean", nullable: false),
                    MessageTemplate = table.Column<string>(type: "text", nullable: true),
                    SendEmail = table.Column<bool>(type: "boolean", nullable: false),
                    SendPush = table.Column<bool>(type: "boolean", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICATION_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "POSITION_LEVEL",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    DefaultBillingMultiplier = table.Column<decimal>(type: "numeric", nullable: false),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSITION_LEVEL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRIORITY",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    DeadlineWarningHours = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRIORITY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PROJECT_ROLE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    CanAssignTasks = table.Column<bool>(type: "boolean", nullable: false),
                    CanApproveActivities = table.Column<bool>(type: "boolean", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT_ROLE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PROJECT_STATUS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsCancelled = table.Column<bool>(type: "boolean", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT_STATUS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PROJECT_TYPE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    DefaultDurationDays = table.Column<int>(type: "integer", nullable: false),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    DefaultTaskTypes = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STEP",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    CanRunParallel = table.Column<bool>(type: "boolean", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STEP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_PARAMETER",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ParameterName = table.Column<string>(type: "text", nullable: true),
                    ParameterValue = table.Column<string>(type: "text", nullable: true),
                    ParameterType = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    IsEditable = table.Column<bool>(type: "boolean", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYSTEM_PARAMETER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TASK_STATUS_TYPE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsCancelled = table.Column<bool>(type: "boolean", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASK_STATUS_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TASK_TYPE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    RequiresAnalysis = table.Column<bool>(type: "boolean", nullable: false),
                    RequiresTesting = table.Column<bool>(type: "boolean", nullable: false),
                    RequiresDeployment = table.Column<bool>(type: "boolean", nullable: false),
                    DefaultEstimatedDays = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASK_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LOCATION",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LocationTypeId = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCATION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LOCATION_LOCATION_TYPE_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LOCATION_TYPE",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TASK_STATUS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    TaskStatusTypeId = table.Column<int>(type: "integer", nullable: false),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsSystemStatus = table.Column<bool>(type: "boolean", nullable: false),
                    TaskStatusTypeId1 = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASK_STATUS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TASK_STATUS_TASK_STATUS_TYPE_TaskStatusTypeId1",
                        column: x => x.TaskStatusTypeId1,
                        principalTable: "TASK_STATUS_TYPE",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_LOCATION",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    LocationName = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    LocationTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    CustomerId1 = table.Column<string>(type: "text", nullable: true),
                    LocationTypeId1 = table.Column<string>(type: "text", nullable: true),
                    LocationId = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_LOCATION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_LOCATION_CUSTOMER_M_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "CUSTOMER_M",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CUSTOMER_LOCATION_LOCATION_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LOCATION",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CUSTOMER_LOCATION_LOCATION_TYPE_LocationTypeId1",
                        column: x => x.LocationTypeId1,
                        principalTable: "LOCATION_TYPE",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ACTIVITY_M",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TaskId = table.Column<string>(type: "text", nullable: true),
                    TaskStepId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    LocationId = table.Column<string>(type: "text", nullable: true),
                    CustomerLocationId = table.Column<string>(type: "text", nullable: true),
                    ActivityStatusId = table.Column<string>(type: "text", nullable: true),
                    ApprovedByUserId = table.Column<string>(type: "text", nullable: true),
                    ActivityDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    TotalMinutes = table.Column<int>(type: "integer", nullable: false),
                    ApprovalNotes = table.Column<string>(type: "text", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTIVITY_M", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ACTIVITY_M_ACTIVITY_STATUS_ActivityStatusId",
                        column: x => x.ActivityStatusId,
                        principalTable: "ACTIVITY_STATUS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACTIVITY_M_CUSTOMER_LOCATION_CustomerLocationId",
                        column: x => x.CustomerLocationId,
                        principalTable: "CUSTOMER_LOCATION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACTIVITY_M_LOCATION_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LOCATION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ATTENDANCE_EXCEPTION",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    ExceptionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AttendanceExceptionTypeId = table.Column<string>(type: "text", nullable: true),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    ApprovedByUserId = table.Column<string>(type: "text", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    MinutesToDeduct = table.Column<int>(type: "integer", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTENDANCE_EXCEPTION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ATTENDANCE_EXCEPTION_ATTENDANCE_EXCEPTION_TYPE_AttendanceEx~",
                        column: x => x.AttendanceExceptionTypeId,
                        principalTable: "ATTENDANCE_EXCEPTION_TYPE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ATTENDANCE_SESSION",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    CheckInLocationId = table.Column<string>(type: "text", nullable: true),
                    CheckOutLocationId = table.Column<string>(type: "text", nullable: true),
                    SessionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CheckOutTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CheckInQRToken = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CheckOutQRToken = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TotalMinutes = table.Column<int>(type: "integer", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    LocationId = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTENDANCE_SESSION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ATTENDANCE_SESSION_LOCATION_CheckInLocationId",
                        column: x => x.CheckInLocationId,
                        principalTable: "LOCATION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ATTENDANCE_SESSION_LOCATION_CheckOutLocationId",
                        column: x => x.CheckOutLocationId,
                        principalTable: "LOCATION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ATTENDANCE_SESSION_LOCATION_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LOCATION",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ATTENDANCE_SUMMARY",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    TotalWorkingDays = table.Column<int>(type: "integer", nullable: false),
                    PresentDays = table.Column<int>(type: "integer", nullable: false),
                    AbsentDays = table.Column<int>(type: "integer", nullable: false),
                    LateDays = table.Column<int>(type: "integer", nullable: false),
                    EarlyLeaveDays = table.Column<int>(type: "integer", nullable: false),
                    TotalWorkedMinutes = table.Column<int>(type: "integer", nullable: false),
                    RequiredWorkedMinutes = table.Column<int>(type: "integer", nullable: false),
                    OvertimeMinutes = table.Column<int>(type: "integer", nullable: false),
                    UndertimeMinutes = table.Column<int>(type: "integer", nullable: false),
                    AverageDailyMinutes = table.Column<int>(type: "integer", nullable: false),
                    VacationDays = table.Column<int>(type: "integer", nullable: false),
                    SickDays = table.Column<int>(type: "integer", nullable: false),
                    OfficialHolidayDays = table.Column<int>(type: "integer", nullable: false),
                    AverageArrivalTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    AverageDepartureTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    AttendanceRate = table.Column<decimal>(type: "numeric", nullable: false),
                    PunctualityRate = table.Column<decimal>(type: "numeric", nullable: false),
                    LastCalculated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTENDANCE_SUMMARY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DAILY_ATTENDANCE_REPORT",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    UserFullName = table.Column<string>(type: "text", nullable: true),
                    DepartmentName = table.Column<string>(type: "text", nullable: true),
                    PositionName = table.Column<string>(type: "text", nullable: true),
                    CheckInTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CheckOutTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WorkedMinutes = table.Column<int>(type: "integer", nullable: false),
                    RequiredMinutes = table.Column<int>(type: "integer", nullable: false),
                    OvertimeMinutes = table.Column<int>(type: "integer", nullable: false),
                    UndertimeMinutes = table.Column<int>(type: "integer", nullable: false),
                    LateMinutes = table.Column<int>(type: "integer", nullable: false),
                    EarlyLeaveMinutes = table.Column<int>(type: "integer", nullable: false),
                    AttendanceStatus = table.Column<string>(type: "text", nullable: true),
                    ExceptionReason = table.Column<string>(type: "text", nullable: true),
                    IsLate = table.Column<bool>(type: "boolean", nullable: false),
                    IsEarlyLeave = table.Column<bool>(type: "boolean", nullable: false),
                    CheckInLocationName = table.Column<string>(type: "text", nullable: true),
                    CheckOutLocationName = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DAILY_ATTENDANCE_REPORT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENT",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ParentDepartmentId = table.Column<string>(type: "text", nullable: true),
                    ManagerId = table.Column<string>(type: "text", nullable: true),
                    LocationId = table.Column<string>(type: "text", nullable: true),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DEPARTMENT_DEPARTMENT_ParentDepartmentId",
                        column: x => x.ParentDepartmentId,
                        principalTable: "DEPARTMENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DEPARTMENT_LOCATION_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LOCATION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "POSITION",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    PositionLevelId = table.Column<int>(type: "integer", nullable: false),
                    BillingMultiplier = table.Column<decimal>(type: "numeric", nullable: false),
                    DepartmentId1 = table.Column<string>(type: "text", nullable: true),
                    PositionLevelId1 = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSITION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_POSITION_DEPARTMENT_DepartmentId1",
                        column: x => x.DepartmentId1,
                        principalTable: "DEPARTMENT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_POSITION_POSITION_LEVEL_PositionLevelId1",
                        column: x => x.PositionLevelId1,
                        principalTable: "POSITION_LEVEL",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TASK_TYPE_STEP",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TaskTypeId = table.Column<string>(type: "text", nullable: false),
                    StepId = table.Column<string>(type: "text", nullable: false),
                    DefaultDepartmentId = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    DefaultDurationDays = table.Column<int>(type: "integer", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASK_TYPE_STEP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TASK_TYPE_STEP_DEPARTMENT_DefaultDepartmentId",
                        column: x => x.DefaultDepartmentId,
                        principalTable: "DEPARTMENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_TYPE_STEP_STEP_StepId",
                        column: x => x.StepId,
                        principalTable: "STEP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_TYPE_STEP_TASK_TYPE_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TASK_TYPE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DepartmentId = table.Column<string>(type: "text", nullable: true),
                    PositionId = table.Column<string>(type: "text", nullable: true),
                    DirectManagerId = table.Column<string>(type: "text", nullable: true),
                    BillingMultiplier = table.Column<decimal>(type: "numeric", nullable: false),
                    LocationId = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_DEPARTMENT_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DEPARTMENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_LOCATION_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LOCATION",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_USER_POSITION_PositionId",
                        column: x => x.PositionId,
                        principalTable: "POSITION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_USER_DirectManagerId",
                        column: x => x.DirectManagerId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LIVE_ATTENDANCE_STATUS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    UserFullName = table.Column<string>(type: "text", nullable: true),
                    DepartmentName = table.Column<string>(type: "text", nullable: true),
                    PositionName = table.Column<string>(type: "text", nullable: true),
                    ProfilePhotoUrl = table.Column<string>(type: "text", nullable: true),
                    IsCurrentlyIn = table.Column<bool>(type: "boolean", nullable: false),
                    LastCheckInTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CurrentLocationName = table.Column<string>(type: "text", nullable: true),
                    CurrentSessionDuration = table.Column<TimeSpan>(type: "interval", nullable: true),
                    TodayTotalMinutes = table.Column<int>(type: "integer", nullable: false),
                    LateMinutesToday = table.Column<int>(type: "integer", nullable: false),
                    TodayFirstCheckIn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TodayLastCheckOut = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TodayStatus = table.Column<string>(type: "text", nullable: true),
                    IsLateToday = table.Column<bool>(type: "boolean", nullable: false),
                    LastActivityDescription = table.Column<string>(type: "text", nullable: true),
                    StatusColor = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIVE_ATTENDANCE_STATUS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LIVE_ATTENDANCE_STATUS_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NOTE_TAG",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    IsSystemTag = table.Column<bool>(type: "boolean", nullable: false),
                    IsShared = table.Column<bool>(type: "boolean", nullable: false),
                    UsageCount = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId1 = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTE_TAG", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NOTE_TAG_USER_CreatedByUserId1",
                        column: x => x.CreatedByUserId1,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NOTIFICATION",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    NotificationTypeId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RelatedEntityId = table.Column<int>(type: "integer", nullable: true),
                    RelatedEntityType = table.Column<string>(type: "text", nullable: true),
                    ActionUrl = table.Column<string>(type: "text", nullable: true),
                    UserId1 = table.Column<string>(type: "text", nullable: true),
                    NotificationTypeId1 = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICATION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NOTIFICATION_NOTIFICATION_TYPE_NotificationTypeId1",
                        column: x => x.NotificationTypeId1,
                        principalTable: "NOTIFICATION_TYPE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NOTIFICATION_USER_UserId1",
                        column: x => x.UserId1,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PROJECT_M",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    ProjectTypeId = table.Column<int>(type: "integer", nullable: false),
                    ProjectManagerId = table.Column<int>(type: "integer", nullable: false),
                    ProjectStatusId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PlannedEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActualEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstimatedDurationDays = table.Column<int>(type: "integer", nullable: false),
                    PriorityId = table.Column<int>(type: "integer", nullable: false),
                    CustomerId1 = table.Column<string>(type: "text", nullable: true),
                    ProjectTypeId1 = table.Column<string>(type: "text", nullable: true),
                    ProjectManagerId1 = table.Column<string>(type: "text", nullable: true),
                    ProjectStatusId1 = table.Column<string>(type: "text", nullable: true),
                    PriorityId1 = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT_M", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PROJECT_M_CUSTOMER_M_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "CUSTOMER_M",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PROJECT_M_PRIORITY_PriorityId1",
                        column: x => x.PriorityId1,
                        principalTable: "PRIORITY",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PROJECT_M_PROJECT_STATUS_ProjectStatusId1",
                        column: x => x.ProjectStatusId1,
                        principalTable: "PROJECT_STATUS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PROJECT_M_PROJECT_TYPE_ProjectTypeId1",
                        column: x => x.ProjectTypeId1,
                        principalTable: "PROJECT_TYPE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PROJECT_M_USER_ProjectManagerId1",
                        column: x => x.ProjectManagerId1,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QR_TOKEN",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Token = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    GeneratedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LocationId = table.Column<string>(type: "text", nullable: true),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    UsedByUserId = table.Column<string>(type: "text", nullable: true),
                    UsedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TokenType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QR_TOKEN", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QR_TOKEN_LOCATION_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LOCATION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QR_TOKEN_USER_UsedByUserId",
                        column: x => x.UsedByUserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER_ATTENDANCE_RULE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    AttendanceRuleId = table.Column<string>(type: "text", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ATTENDANCE_RULE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_ATTENDANCE_RULE_ATTENDANCE_RULE_AttendanceRuleId",
                        column: x => x.AttendanceRuleId,
                        principalTable: "ATTENDANCE_RULE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_USER_ATTENDANCE_RULE_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "USER_DASHBOARD_WIDGET",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    DashboardWidgetId = table.Column<int>(type: "integer", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    CustomTitle = table.Column<string>(type: "text", nullable: true),
                    PersonalConfigurationJson = table.Column<string>(type: "text", nullable: true),
                    UserId1 = table.Column<string>(type: "text", nullable: true),
                    DashboardWidgetId1 = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_DASHBOARD_WIDGET", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_DASHBOARD_WIDGET_DASHBOARD_WIDGET_DashboardWidgetId1",
                        column: x => x.DashboardWidgetId1,
                        principalTable: "DASHBOARD_WIDGET",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_USER_DASHBOARD_WIDGET_USER_UserId1",
                        column: x => x.UserId1,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NOTEBOOK",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsShared = table.Column<bool>(type: "boolean", nullable: false),
                    IsTeamNotebook = table.Column<bool>(type: "boolean", nullable: false),
                    RelatedProjectId = table.Column<int>(type: "integer", nullable: true),
                    RelatedCustomerId = table.Column<int>(type: "integer", nullable: true),
                    TotalSections = table.Column<int>(type: "integer", nullable: false),
                    TotalPages = table.Column<int>(type: "integer", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OwnerId1 = table.Column<string>(type: "text", nullable: true),
                    RelatedProjectId1 = table.Column<string>(type: "text", nullable: true),
                    RelatedCustomerId1 = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTEBOOK", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NOTEBOOK_CUSTOMER_M_RelatedCustomerId1",
                        column: x => x.RelatedCustomerId1,
                        principalTable: "CUSTOMER_M",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NOTEBOOK_PROJECT_M_RelatedProjectId1",
                        column: x => x.RelatedProjectId1,
                        principalTable: "PROJECT_M",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NOTEBOOK_USER_OwnerId1",
                        column: x => x.OwnerId1,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PROJECT_TEAM_MEMBER",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProjectRoleId = table.Column<int>(type: "integer", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AllocationPercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    ProjectId1 = table.Column<string>(type: "text", nullable: true),
                    UserId1 = table.Column<string>(type: "text", nullable: true),
                    ProjectRoleId1 = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT_TEAM_MEMBER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PROJECT_TEAM_MEMBER_PROJECT_M_ProjectId1",
                        column: x => x.ProjectId1,
                        principalTable: "PROJECT_M",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PROJECT_TEAM_MEMBER_PROJECT_ROLE_ProjectRoleId1",
                        column: x => x.ProjectRoleId1,
                        principalTable: "PROJECT_ROLE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PROJECT_TEAM_MEMBER_USER_UserId1",
                        column: x => x.UserId1,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TASK_M",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CustomerId = table.Column<string>(type: "text", nullable: true),
                    ProjectId = table.Column<string>(type: "text", nullable: true),
                    TaskTypeId = table.Column<string>(type: "text", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    MainResponsibleUserId = table.Column<string>(type: "text", nullable: true),
                    TaskStatusId = table.Column<string>(type: "text", nullable: true),
                    PriorityId = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeadlineDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TotalEstimatedDays = table.Column<int>(type: "integer", nullable: false),
                    TotalBillingDays = table.Column<decimal>(type: "numeric", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASK_M", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TASK_M_CUSTOMER_M_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CUSTOMER_M",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_M_PRIORITY_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "PRIORITY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_M_PROJECT_M_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "PROJECT_M",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_M_TASK_STATUS_TaskStatusId",
                        column: x => x.TaskStatusId,
                        principalTable: "TASK_STATUS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_M_TASK_TYPE_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TASK_TYPE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_M_USER_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_M_USER_MainResponsibleUserId",
                        column: x => x.MainResponsibleUserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NOTEBOOK_PERMISSION",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    NotebookId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    PermissionTypeId = table.Column<string>(type: "text", nullable: true),
                    CanRead = table.Column<bool>(type: "boolean", nullable: false),
                    CanWrite = table.Column<bool>(type: "boolean", nullable: false),
                    CanDelete = table.Column<bool>(type: "boolean", nullable: false),
                    CanShare = table.Column<bool>(type: "boolean", nullable: false),
                    CanAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    GrantedByUserId = table.Column<string>(type: "text", nullable: true),
                    GrantedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTEBOOK_PERMISSION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NOTEBOOK_PERMISSION_NOTEBOOK_NotebookId",
                        column: x => x.NotebookId,
                        principalTable: "NOTEBOOK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTEBOOK_PERMISSION_NOTE_PERMISSION_TYPE_PermissionTypeId",
                        column: x => x.PermissionTypeId,
                        principalTable: "NOTE_PERMISSION_TYPE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTEBOOK_PERMISSION_USER_GrantedByUserId",
                        column: x => x.GrantedByUserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTEBOOK_PERMISSION_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NOTEBOOK_SECTION",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    NotebookId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsLocked = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    TotalPages = table.Column<int>(type: "integer", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NotebookId1 = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTEBOOK_SECTION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NOTEBOOK_SECTION_NOTEBOOK_NotebookId1",
                        column: x => x.NotebookId1,
                        principalTable: "NOTEBOOK",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TASK_STEP",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false),
                    StepId = table.Column<int>(type: "integer", nullable: false),
                    AssignedUserId = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstimatedDurationDays = table.Column<int>(type: "integer", nullable: false),
                    BillingMultiplier = table.Column<decimal>(type: "numeric", nullable: false),
                    BillingDurationDays = table.Column<decimal>(type: "numeric", nullable: false),
                    TaskStatusId = table.Column<int>(type: "integer", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Dependencies = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    TaskId1 = table.Column<string>(type: "text", nullable: true),
                    StepId1 = table.Column<string>(type: "text", nullable: true),
                    AssignedUserId1 = table.Column<string>(type: "text", nullable: true),
                    DepartmentId1 = table.Column<string>(type: "text", nullable: true),
                    TaskStatusId1 = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASK_STEP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TASK_STEP_DEPARTMENT_DepartmentId1",
                        column: x => x.DepartmentId1,
                        principalTable: "DEPARTMENT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TASK_STEP_STEP_StepId1",
                        column: x => x.StepId1,
                        principalTable: "STEP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TASK_STEP_TASK_M_TaskId1",
                        column: x => x.TaskId1,
                        principalTable: "TASK_M",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TASK_STEP_TASK_STATUS_TaskStatusId1",
                        column: x => x.TaskStatusId1,
                        principalTable: "TASK_STATUS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TASK_STEP_USER_AssignedUserId1",
                        column: x => x.AssignedUserId1,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TASK_TODO_ITEM",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TaskId = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AssignedUserId = table.Column<string>(type: "text", nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CompletedByUserId = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    ParentTodoItemId = table.Column<string>(type: "text", nullable: true),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PriorityId = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASK_TODO_ITEM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TASK_TODO_ITEM_PRIORITY_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "PRIORITY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_TODO_ITEM_TASK_M_TaskId",
                        column: x => x.TaskId,
                        principalTable: "TASK_M",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_TODO_ITEM_TASK_TODO_ITEM_ParentTodoItemId",
                        column: x => x.ParentTodoItemId,
                        principalTable: "TASK_TODO_ITEM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_TODO_ITEM_USER_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_TODO_ITEM_USER_CompletedByUserId",
                        column: x => x.CompletedByUserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NOTE_PAGE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    NotebookSectionId = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    ContentType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastModifiedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsFavorite = table.Column<bool>(type: "boolean", nullable: false),
                    IsPinned = table.Column<bool>(type: "boolean", nullable: false),
                    IsTemplate = table.Column<bool>(type: "boolean", nullable: false),
                    RelatedTaskId = table.Column<string>(type: "text", nullable: true),
                    RelatedProjectId = table.Column<string>(type: "text", nullable: true),
                    RelatedCustomerId = table.Column<string>(type: "text", nullable: true),
                    SearchableContent = table.Column<string>(type: "text", nullable: true),
                    ContentWordCount = table.Column<int>(type: "integer", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTE_PAGE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NOTE_PAGE_CUSTOMER_M_RelatedCustomerId",
                        column: x => x.RelatedCustomerId,
                        principalTable: "CUSTOMER_M",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NOTE_PAGE_NOTEBOOK_SECTION_NotebookSectionId",
                        column: x => x.NotebookSectionId,
                        principalTable: "NOTEBOOK_SECTION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTE_PAGE_PROJECT_M_RelatedProjectId",
                        column: x => x.RelatedProjectId,
                        principalTable: "PROJECT_M",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NOTE_PAGE_TASK_M_RelatedTaskId",
                        column: x => x.RelatedTaskId,
                        principalTable: "TASK_M",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTE_PAGE_USER_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTE_PAGE_USER_LastModifiedByUserId",
                        column: x => x.LastModifiedByUserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NOTE_COMMENT",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    NotePageId = table.Column<string>(type: "text", nullable: true),
                    AuthorId = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    ParentCommentId = table.Column<string>(type: "text", nullable: true),
                    IsResolved = table.Column<bool>(type: "boolean", nullable: false),
                    ResolvedByUserId = table.Column<string>(type: "text", nullable: true),
                    ResolvedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AnchorText = table.Column<string>(type: "text", nullable: true),
                    CharacterPosition = table.Column<int>(type: "integer", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTE_COMMENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NOTE_COMMENT_NOTE_COMMENT_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "NOTE_COMMENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTE_COMMENT_NOTE_PAGE_NotePageId",
                        column: x => x.NotePageId,
                        principalTable: "NOTE_PAGE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTE_COMMENT_USER_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTE_COMMENT_USER_ResolvedByUserId",
                        column: x => x.ResolvedByUserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NOTE_PAGE_ATTACHMENT",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    NotePageId = table.Column<string>(type: "text", nullable: true),
                    FileName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    ContentType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    FileUrl = table.Column<string>(type: "text", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: true),
                    AttachmentType = table.Column<string>(type: "text", nullable: true),
                    LinkUrl = table.Column<string>(type: "text", nullable: true),
                    LinkTitle = table.Column<string>(type: "text", nullable: true),
                    UploadedByUserId = table.Column<string>(type: "text", nullable: true),
                    UploadedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsEmbedded = table.Column<bool>(type: "boolean", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTE_PAGE_ATTACHMENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NOTE_PAGE_ATTACHMENT_NOTE_PAGE_NotePageId",
                        column: x => x.NotePageId,
                        principalTable: "NOTE_PAGE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTE_PAGE_ATTACHMENT_USER_UploadedByUserId",
                        column: x => x.UploadedByUserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NOTE_PAGE_TAG",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    NotePageId = table.Column<string>(type: "text", nullable: true),
                    NoteTagId = table.Column<string>(type: "text", nullable: true),
                    AddedByUserId = table.Column<string>(type: "text", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTE_PAGE_TAG", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NOTE_PAGE_TAG_NOTE_PAGE_NotePageId",
                        column: x => x.NotePageId,
                        principalTable: "NOTE_PAGE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTE_PAGE_TAG_NOTE_TAG_NoteTagId",
                        column: x => x.NoteTagId,
                        principalTable: "NOTE_TAG",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTE_PAGE_TAG_USER_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITY_M_ActivityStatusId",
                table: "ACTIVITY_M",
                column: "ActivityStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITY_M_ApprovedByUserId",
                table: "ACTIVITY_M",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITY_M_CustomerLocationId",
                table: "ACTIVITY_M",
                column: "CustomerLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITY_M_LocationId",
                table: "ACTIVITY_M",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITY_M_TaskId",
                table: "ACTIVITY_M",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITY_M_TaskStepId",
                table: "ACTIVITY_M",
                column: "TaskStepId");

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITY_M_UserId_ActivityDate",
                table: "ACTIVITY_M",
                columns: new[] { "UserId", "ActivityDate" });

            migrationBuilder.CreateIndex(
                name: "IX_ATTENDANCE_EXCEPTION_ApprovedByUserId",
                table: "ATTENDANCE_EXCEPTION",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ATTENDANCE_EXCEPTION_AttendanceExceptionTypeId",
                table: "ATTENDANCE_EXCEPTION",
                column: "AttendanceExceptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ATTENDANCE_EXCEPTION_UserId",
                table: "ATTENDANCE_EXCEPTION",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ATTENDANCE_SESSION_CheckInLocationId",
                table: "ATTENDANCE_SESSION",
                column: "CheckInLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ATTENDANCE_SESSION_CheckOutLocationId",
                table: "ATTENDANCE_SESSION",
                column: "CheckOutLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ATTENDANCE_SESSION_LocationId",
                table: "ATTENDANCE_SESSION",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ATTENDANCE_SESSION_UserId_SessionDate",
                table: "ATTENDANCE_SESSION",
                columns: new[] { "UserId", "SessionDate" });

            migrationBuilder.CreateIndex(
                name: "IX_ATTENDANCE_SUMMARY_UserId",
                table: "ATTENDANCE_SUMMARY",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_LOCATION_CustomerId1",
                table: "CUSTOMER_LOCATION",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_LOCATION_LocationId",
                table: "CUSTOMER_LOCATION",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_LOCATION_LocationTypeId1",
                table: "CUSTOMER_LOCATION",
                column: "LocationTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_DAILY_ATTENDANCE_REPORT_UserId",
                table: "DAILY_ATTENDANCE_REPORT",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENT_LocationId",
                table: "DEPARTMENT",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENT_ManagerId",
                table: "DEPARTMENT",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENT_ParentDepartmentId",
                table: "DEPARTMENT",
                column: "ParentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LIVE_ATTENDANCE_STATUS_UserId",
                table: "LIVE_ATTENDANCE_STATUS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LOCATION_LocationTypeId",
                table: "LOCATION",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_COMMENT_AuthorId",
                table: "NOTE_COMMENT",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_COMMENT_NotePageId",
                table: "NOTE_COMMENT",
                column: "NotePageId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_COMMENT_ParentCommentId",
                table: "NOTE_COMMENT",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_COMMENT_ResolvedByUserId",
                table: "NOTE_COMMENT",
                column: "ResolvedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_PAGE_CreatedByUserId",
                table: "NOTE_PAGE",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_PAGE_LastModifiedByUserId",
                table: "NOTE_PAGE",
                column: "LastModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_PAGE_NotebookSectionId_SortOrder",
                table: "NOTE_PAGE",
                columns: new[] { "NotebookSectionId", "SortOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_PAGE_RelatedCustomerId",
                table: "NOTE_PAGE",
                column: "RelatedCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_PAGE_RelatedProjectId",
                table: "NOTE_PAGE",
                column: "RelatedProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_PAGE_RelatedTaskId",
                table: "NOTE_PAGE",
                column: "RelatedTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_PAGE_ATTACHMENT_NotePageId",
                table: "NOTE_PAGE_ATTACHMENT",
                column: "NotePageId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_PAGE_ATTACHMENT_UploadedByUserId",
                table: "NOTE_PAGE_ATTACHMENT",
                column: "UploadedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_PAGE_TAG_AddedByUserId",
                table: "NOTE_PAGE_TAG",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_PAGE_TAG_NotePageId_NoteTagId",
                table: "NOTE_PAGE_TAG",
                columns: new[] { "NotePageId", "NoteTagId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_PAGE_TAG_NoteTagId",
                table: "NOTE_PAGE_TAG",
                column: "NoteTagId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_TAG_CreatedByUserId1",
                table: "NOTE_TAG",
                column: "CreatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_NOTEBOOK_OwnerId1",
                table: "NOTEBOOK",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_NOTEBOOK_RelatedCustomerId1",
                table: "NOTEBOOK",
                column: "RelatedCustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_NOTEBOOK_RelatedProjectId1",
                table: "NOTEBOOK",
                column: "RelatedProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_NOTEBOOK_PERMISSION_GrantedByUserId",
                table: "NOTEBOOK_PERMISSION",
                column: "GrantedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTEBOOK_PERMISSION_NotebookId",
                table: "NOTEBOOK_PERMISSION",
                column: "NotebookId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTEBOOK_PERMISSION_PermissionTypeId",
                table: "NOTEBOOK_PERMISSION",
                column: "PermissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTEBOOK_PERMISSION_UserId",
                table: "NOTEBOOK_PERMISSION",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTEBOOK_SECTION_NotebookId1",
                table: "NOTEBOOK_SECTION",
                column: "NotebookId1");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATION_NotificationTypeId1",
                table: "NOTIFICATION",
                column: "NotificationTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATION_UserId1",
                table: "NOTIFICATION",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_POSITION_DepartmentId1",
                table: "POSITION",
                column: "DepartmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_POSITION_PositionLevelId1",
                table: "POSITION",
                column: "PositionLevelId1");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_M_CustomerId1",
                table: "PROJECT_M",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_M_PriorityId1",
                table: "PROJECT_M",
                column: "PriorityId1");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_M_ProjectManagerId1",
                table: "PROJECT_M",
                column: "ProjectManagerId1");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_M_ProjectStatusId1",
                table: "PROJECT_M",
                column: "ProjectStatusId1");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_M_ProjectTypeId1",
                table: "PROJECT_M",
                column: "ProjectTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_TEAM_MEMBER_ProjectId1",
                table: "PROJECT_TEAM_MEMBER",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_TEAM_MEMBER_ProjectRoleId1",
                table: "PROJECT_TEAM_MEMBER",
                column: "ProjectRoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_TEAM_MEMBER_UserId1",
                table: "PROJECT_TEAM_MEMBER",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QR_TOKEN_LocationId",
                table: "QR_TOKEN",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_QR_TOKEN_Token",
                table: "QR_TOKEN",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QR_TOKEN_UsedByUserId",
                table: "QR_TOKEN",
                column: "UsedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_M_CreatedByUserId",
                table: "TASK_M",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_M_CustomerId_ProjectId",
                table: "TASK_M",
                columns: new[] { "CustomerId", "ProjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_TASK_M_MainResponsibleUserId",
                table: "TASK_M",
                column: "MainResponsibleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_M_PriorityId",
                table: "TASK_M",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_M_ProjectId",
                table: "TASK_M",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_M_TaskStatusId",
                table: "TASK_M",
                column: "TaskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_M_TaskTypeId",
                table: "TASK_M",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_STATUS_TaskStatusTypeId1",
                table: "TASK_STATUS",
                column: "TaskStatusTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_STEP_AssignedUserId1",
                table: "TASK_STEP",
                column: "AssignedUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_STEP_DepartmentId1",
                table: "TASK_STEP",
                column: "DepartmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_STEP_StepId1",
                table: "TASK_STEP",
                column: "StepId1");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_STEP_TaskId1",
                table: "TASK_STEP",
                column: "TaskId1");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_STEP_TaskStatusId1",
                table: "TASK_STEP",
                column: "TaskStatusId1");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_TODO_ITEM_AssignedUserId",
                table: "TASK_TODO_ITEM",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_TODO_ITEM_CompletedByUserId",
                table: "TASK_TODO_ITEM",
                column: "CompletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_TODO_ITEM_ParentTodoItemId",
                table: "TASK_TODO_ITEM",
                column: "ParentTodoItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_TODO_ITEM_PriorityId",
                table: "TASK_TODO_ITEM",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_TODO_ITEM_TaskId_SortOrder",
                table: "TASK_TODO_ITEM",
                columns: new[] { "TaskId", "SortOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_TASK_TYPE_STEP_DefaultDepartmentId",
                table: "TASK_TYPE_STEP",
                column: "DefaultDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_TYPE_STEP_StepId",
                table: "TASK_TYPE_STEP",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_TYPE_STEP_TaskTypeId_SortOrder",
                table: "TASK_TYPE_STEP",
                columns: new[] { "TaskTypeId", "SortOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_USER_DepartmentId",
                table: "USER",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_DirectManagerId",
                table: "USER",
                column: "DirectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_Email",
                table: "USER",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USER_LocationId",
                table: "USER",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_PositionId",
                table: "USER",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ATTENDANCE_RULE_AttendanceRuleId",
                table: "USER_ATTENDANCE_RULE",
                column: "AttendanceRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ATTENDANCE_RULE_UserId",
                table: "USER_ATTENDANCE_RULE",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_DASHBOARD_WIDGET_DashboardWidgetId1",
                table: "USER_DASHBOARD_WIDGET",
                column: "DashboardWidgetId1");

            migrationBuilder.CreateIndex(
                name: "IX_USER_DASHBOARD_WIDGET_UserId1",
                table: "USER_DASHBOARD_WIDGET",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ACTIVITY_M_TASK_M_TaskId",
                table: "ACTIVITY_M",
                column: "TaskId",
                principalTable: "TASK_M",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ACTIVITY_M_TASK_STEP_TaskStepId",
                table: "ACTIVITY_M",
                column: "TaskStepId",
                principalTable: "TASK_STEP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ACTIVITY_M_USER_ApprovedByUserId",
                table: "ACTIVITY_M",
                column: "ApprovedByUserId",
                principalTable: "USER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ACTIVITY_M_USER_UserId",
                table: "ACTIVITY_M",
                column: "UserId",
                principalTable: "USER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ATTENDANCE_EXCEPTION_USER_ApprovedByUserId",
                table: "ATTENDANCE_EXCEPTION",
                column: "ApprovedByUserId",
                principalTable: "USER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ATTENDANCE_EXCEPTION_USER_UserId",
                table: "ATTENDANCE_EXCEPTION",
                column: "UserId",
                principalTable: "USER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ATTENDANCE_SESSION_USER_UserId",
                table: "ATTENDANCE_SESSION",
                column: "UserId",
                principalTable: "USER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ATTENDANCE_SUMMARY_USER_UserId",
                table: "ATTENDANCE_SUMMARY",
                column: "UserId",
                principalTable: "USER",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DAILY_ATTENDANCE_REPORT_USER_UserId",
                table: "DAILY_ATTENDANCE_REPORT",
                column: "UserId",
                principalTable: "USER",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DEPARTMENT_USER_ManagerId",
                table: "DEPARTMENT",
                column: "ManagerId",
                principalTable: "USER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DEPARTMENT_LOCATION_LocationId",
                table: "DEPARTMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_USER_LOCATION_LocationId",
                table: "USER");

            migrationBuilder.DropForeignKey(
                name: "FK_DEPARTMENT_USER_ManagerId",
                table: "DEPARTMENT");

            migrationBuilder.DropTable(
                name: "ACTIVITY_M");

            migrationBuilder.DropTable(
                name: "ATTENDANCE_EXCEPTION");

            migrationBuilder.DropTable(
                name: "ATTENDANCE_SESSION");

            migrationBuilder.DropTable(
                name: "ATTENDANCE_SUMMARY");

            migrationBuilder.DropTable(
                name: "CODE_TEMPLATE");

            migrationBuilder.DropTable(
                name: "DAILY_ATTENDANCE_REPORT");

            migrationBuilder.DropTable(
                name: "LIVE_ATTENDANCE_STATUS");

            migrationBuilder.DropTable(
                name: "NOTE_COMMENT");

            migrationBuilder.DropTable(
                name: "NOTE_PAGE_ATTACHMENT");

            migrationBuilder.DropTable(
                name: "NOTE_PAGE_TAG");

            migrationBuilder.DropTable(
                name: "NOTEBOOK_PERMISSION");

            migrationBuilder.DropTable(
                name: "NOTIFICATION");

            migrationBuilder.DropTable(
                name: "PROJECT_TEAM_MEMBER");

            migrationBuilder.DropTable(
                name: "QR_TOKEN");

            migrationBuilder.DropTable(
                name: "SYSTEM_PARAMETER");

            migrationBuilder.DropTable(
                name: "TASK_TODO_ITEM");

            migrationBuilder.DropTable(
                name: "TASK_TYPE_STEP");

            migrationBuilder.DropTable(
                name: "USER_ATTENDANCE_RULE");

            migrationBuilder.DropTable(
                name: "USER_DASHBOARD_WIDGET");

            migrationBuilder.DropTable(
                name: "ACTIVITY_STATUS");

            migrationBuilder.DropTable(
                name: "CUSTOMER_LOCATION");

            migrationBuilder.DropTable(
                name: "TASK_STEP");

            migrationBuilder.DropTable(
                name: "ATTENDANCE_EXCEPTION_TYPE");

            migrationBuilder.DropTable(
                name: "NOTE_PAGE");

            migrationBuilder.DropTable(
                name: "NOTE_TAG");

            migrationBuilder.DropTable(
                name: "NOTE_PERMISSION_TYPE");

            migrationBuilder.DropTable(
                name: "NOTIFICATION_TYPE");

            migrationBuilder.DropTable(
                name: "PROJECT_ROLE");

            migrationBuilder.DropTable(
                name: "ATTENDANCE_RULE");

            migrationBuilder.DropTable(
                name: "DASHBOARD_WIDGET");

            migrationBuilder.DropTable(
                name: "STEP");

            migrationBuilder.DropTable(
                name: "NOTEBOOK_SECTION");

            migrationBuilder.DropTable(
                name: "TASK_M");

            migrationBuilder.DropTable(
                name: "NOTEBOOK");

            migrationBuilder.DropTable(
                name: "TASK_STATUS");

            migrationBuilder.DropTable(
                name: "TASK_TYPE");

            migrationBuilder.DropTable(
                name: "PROJECT_M");

            migrationBuilder.DropTable(
                name: "TASK_STATUS_TYPE");

            migrationBuilder.DropTable(
                name: "CUSTOMER_M");

            migrationBuilder.DropTable(
                name: "PRIORITY");

            migrationBuilder.DropTable(
                name: "PROJECT_STATUS");

            migrationBuilder.DropTable(
                name: "PROJECT_TYPE");

            migrationBuilder.DropTable(
                name: "LOCATION");

            migrationBuilder.DropTable(
                name: "LOCATION_TYPE");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "POSITION");

            migrationBuilder.DropTable(
                name: "DEPARTMENT");

            migrationBuilder.DropTable(
                name: "POSITION_LEVEL");
        }
    }
}
