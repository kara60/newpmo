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
                name: "ERROR_LOG",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    StackTrace = table.Column<string>(type: "text", nullable: true),
                    RequestPath = table.Column<string>(type: "text", nullable: true),
                    RequestMethod = table.Column<string>(type: "text", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERROR_LOG", x => x.Id);
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
                    QRCode = table.Column<string>(type: "text", nullable: true),
                    IsQREnabled = table.Column<bool>(type: "boolean", nullable: false),
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
                    TaskStatusTypeId = table.Column<string>(type: "text", nullable: true),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsSystemStatus = table.Column<bool>(type: "boolean", nullable: false),
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
                        name: "FK_TASK_STATUS_TASK_STATUS_TYPE_TaskStatusTypeId",
                        column: x => x.TaskStatusTypeId,
                        principalTable: "TASK_STATUS_TYPE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_LOCATION",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<string>(type: "text", nullable: true),
                    LocationName = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    LocationTypeId = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
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
                        name: "FK_CUSTOMER_LOCATION_CUSTOMER_M_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CUSTOMER_M",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_LOCATION_LOCATION_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LOCATION",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CUSTOMER_LOCATION_LOCATION_TYPE_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LOCATION_TYPE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    ApprovedByUserId = table.Column<string>(type: "text", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DurationMinutes = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ApprovalNote = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ActivityStatusId = table.Column<string>(type: "text", nullable: true),
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
                        principalColumn: "Id");
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
                    DepartmentId = table.Column<string>(type: "text", nullable: true),
                    PositionLevelId = table.Column<string>(type: "text", nullable: true),
                    BillingMultiplier = table.Column<decimal>(type: "numeric", nullable: false),
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
                        name: "FK_POSITION_DEPARTMENT_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DEPARTMENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_POSITION_POSITION_LEVEL_PositionLevelId",
                        column: x => x.PositionLevelId,
                        principalTable: "POSITION_LEVEL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "NOTIFICATION_M",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    NotificationType = table.Column<string>(type: "text", nullable: true),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    ReadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RelatedEntityId = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICATION_M", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NOTIFICATION_M_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PROJECT_M",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<string>(type: "text", nullable: true),
                    ProjectTypeId = table.Column<string>(type: "text", nullable: true),
                    ProjectManagerId = table.Column<string>(type: "text", nullable: true),
                    ProjectStatusId = table.Column<string>(type: "text", nullable: true),
                    PriorityId = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PlannedEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActualEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstimatedDurationDays = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_PROJECT_M_CUSTOMER_M_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CUSTOMER_M",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PROJECT_M_PRIORITY_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "PRIORITY",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PROJECT_M_PROJECT_STATUS_ProjectStatusId",
                        column: x => x.ProjectStatusId,
                        principalTable: "PROJECT_STATUS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PROJECT_M_PROJECT_TYPE_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "PROJECT_TYPE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PROJECT_M_USER_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PROJECT_TEAM_MEMBER",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    ProjectRoleId = table.Column<string>(type: "text", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AllocationPercentage = table.Column<decimal>(type: "numeric", nullable: true),
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
                        name: "FK_PROJECT_TEAM_MEMBER_PROJECT_M_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "PROJECT_M",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PROJECT_TEAM_MEMBER_PROJECT_ROLE_ProjectRoleId",
                        column: x => x.ProjectRoleId,
                        principalTable: "PROJECT_ROLE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PROJECT_TEAM_MEMBER_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TASK_M",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    CustomerId = table.Column<string>(type: "text", nullable: true),
                    ProjectId = table.Column<string>(type: "text", nullable: true),
                    TaskTypeId = table.Column<string>(type: "text", nullable: true),
                    MainResponsibleUserId = table.Column<string>(type: "text", nullable: true),
                    DepartmentId = table.Column<string>(type: "text", nullable: true),
                    TaskStatusId = table.Column<string>(type: "text", nullable: true),
                    PriorityId = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstimatedDurationDays = table.Column<int>(type: "integer", nullable: false),
                    BillingMultiplier = table.Column<decimal>(type: "numeric", nullable: false),
                    BillingDuration = table.Column<decimal>(type: "numeric", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
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
                        name: "FK_TASK_M_DEPARTMENT_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DEPARTMENT",
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
                        name: "FK_TASK_M_USER_MainResponsibleUserId",
                        column: x => x.MainResponsibleUserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_M_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TASK_STEP",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TaskId = table.Column<string>(type: "text", nullable: true),
                    StepId = table.Column<string>(type: "text", nullable: true),
                    AssignedUserId = table.Column<string>(type: "text", nullable: true),
                    DepartmentId = table.Column<string>(type: "text", nullable: true),
                    TaskStatusId = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstimatedDurationDays = table.Column<int>(type: "integer", nullable: false),
                    BillingMultiplier = table.Column<decimal>(type: "numeric", nullable: false),
                    BillingDurationDays = table.Column<decimal>(type: "numeric", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Dependencies = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
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
                        name: "FK_TASK_STEP_DEPARTMENT_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DEPARTMENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_STEP_STEP_StepId",
                        column: x => x.StepId,
                        principalTable: "STEP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_STEP_TASK_M_TaskId",
                        column: x => x.TaskId,
                        principalTable: "TASK_M",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_STEP_TASK_STATUS_TaskStatusId",
                        column: x => x.TaskStatusId,
                        principalTable: "TASK_STATUS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASK_STEP_USER_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_ACTIVITY_M_IsApproved_ApprovedByUserId",
                table: "ACTIVITY_M",
                columns: new[] { "IsApproved", "ApprovedByUserId" });

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
                name: "IX_ACTIVITY_M_UserId_StartTime",
                table: "ACTIVITY_M",
                columns: new[] { "UserId", "StartTime" });

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
                name: "IX_CODE_TEMPLATE_EntityType",
                table: "CODE_TEMPLATE",
                column: "EntityType");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_LOCATION_CustomerId",
                table: "CUSTOMER_LOCATION",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_LOCATION_LocationId",
                table: "CUSTOMER_LOCATION",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_LOCATION_LocationTypeId",
                table: "CUSTOMER_LOCATION",
                column: "LocationTypeId");

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
                name: "IX_LOCATION_LocationTypeId",
                table: "LOCATION",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATION_M_UserId",
                table: "NOTIFICATION_M",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_POSITION_DepartmentId",
                table: "POSITION",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_POSITION_PositionLevelId",
                table: "POSITION",
                column: "PositionLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_M_CustomerId",
                table: "PROJECT_M",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_M_PriorityId",
                table: "PROJECT_M",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_M_ProjectManagerId",
                table: "PROJECT_M",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_M_ProjectStatusId",
                table: "PROJECT_M",
                column: "ProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_M_ProjectTypeId",
                table: "PROJECT_M",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_TEAM_MEMBER_ProjectId",
                table: "PROJECT_TEAM_MEMBER",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_TEAM_MEMBER_ProjectRoleId",
                table: "PROJECT_TEAM_MEMBER",
                column: "ProjectRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_TEAM_MEMBER_UserId",
                table: "PROJECT_TEAM_MEMBER",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_M_CustomerId_ProjectId",
                table: "TASK_M",
                columns: new[] { "CustomerId", "ProjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_TASK_M_DepartmentId",
                table: "TASK_M",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_M_DueDate",
                table: "TASK_M",
                column: "DueDate");

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
                name: "IX_TASK_M_UserId",
                table: "TASK_M",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_STATUS_TaskStatusTypeId",
                table: "TASK_STATUS",
                column: "TaskStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_STEP_AssignedUserId",
                table: "TASK_STEP",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_STEP_DepartmentId",
                table: "TASK_STEP",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_STEP_StepId",
                table: "TASK_STEP",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_STEP_TaskId",
                table: "TASK_STEP",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_STEP_TaskStatusId",
                table: "TASK_STEP",
                column: "TaskStatusId");

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
                name: "FK_ATTENDANCE_SESSION_USER_UserId",
                table: "ATTENDANCE_SESSION",
                column: "UserId",
                principalTable: "USER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "ATTENDANCE_SESSION");

            migrationBuilder.DropTable(
                name: "CODE_TEMPLATE");

            migrationBuilder.DropTable(
                name: "ERROR_LOG");

            migrationBuilder.DropTable(
                name: "NOTIFICATION_M");

            migrationBuilder.DropTable(
                name: "PROJECT_TEAM_MEMBER");

            migrationBuilder.DropTable(
                name: "SYSTEM_PARAMETER");

            migrationBuilder.DropTable(
                name: "TASK_TODO_ITEM");

            migrationBuilder.DropTable(
                name: "TASK_TYPE_STEP");

            migrationBuilder.DropTable(
                name: "ACTIVITY_STATUS");

            migrationBuilder.DropTable(
                name: "CUSTOMER_LOCATION");

            migrationBuilder.DropTable(
                name: "TASK_STEP");

            migrationBuilder.DropTable(
                name: "PROJECT_ROLE");

            migrationBuilder.DropTable(
                name: "STEP");

            migrationBuilder.DropTable(
                name: "TASK_M");

            migrationBuilder.DropTable(
                name: "PROJECT_M");

            migrationBuilder.DropTable(
                name: "TASK_STATUS");

            migrationBuilder.DropTable(
                name: "TASK_TYPE");

            migrationBuilder.DropTable(
                name: "CUSTOMER_M");

            migrationBuilder.DropTable(
                name: "PRIORITY");

            migrationBuilder.DropTable(
                name: "PROJECT_STATUS");

            migrationBuilder.DropTable(
                name: "PROJECT_TYPE");

            migrationBuilder.DropTable(
                name: "TASK_STATUS_TYPE");

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
