using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGetProduct_SP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = """
                CREATE OR ALTER PROCEDURE [dbo].[GetProducts] 
                	@PageIndex int,
                	@PageSize int,
                	@OrderBy nvarchar(50),
                	@Name nvarchar(250) = '%',
                	@PriceFrom float = null,
                	@PriceTo float = null,
                	@IsAvailable bit = null,
                	@Total int output,
                	@TotalDisplay int output

                AS
                BEGIN
                	Declare @sql nvarchar(2000);
                	Declare @paramList nvarchar(MAX);

                	Declare @countSql nvarchar(2000);
                	Declare @countParamList nvarchar(MAX);

                	-- Total data count
                	Select @Total = count(*) from Products;

                	-- Preparing count query
                	SET @countSql = 'select @xTotalDisplay = count(*) from Products 
                					where 1 = 1 ';

                	IF @Name IS NOT NULL
                	SET @countSql = @countSql + ' AND Name LIKE ''%'' + @xName + ''%'''

                	IF @PriceFrom IS NOT NULL
                	SET @countSql = @countSql + ' AND Price >= @xPrice'

                	IF @PriceTo IS NOT NULL
                	SET @countSql = @countSql + ' AND Price <= @xPRice'

                	IF @IsAvailable IS NOT NULL
                	SET @countSql = @countSql + ' AND IsAvailable = @xIsAvailable'


                	-- Preparing main query
                	SET @sql = 'select * from Products where 1 = 1 ';

                	IF @Name IS NOT NULL
                	SET @sql = @sql + ' AND Name LIKE ''%'' + @xName + ''%'''

                	IF @PriceFrom IS NOT NULL
                	SET @sql = @sql + ' AND Price >= @xPrice'

                	IF @PriceTo IS NOT NULL
                	SET @sql = @sql + ' AND Price <= @xPRice'

                	IF @IsAvailable IS NOT NULL
                	SET @sql = @sql + ' AND IsAvailable = @xIsAvailable'

                	SET @sql = @sql + ' Order by ' + @OrderBy + ' OFFSET @xPageSize * (@xPageIndex - 1)
                	ROWS FETCH NEXT @xPageSize ROWS ONLY';

                	-- Preparing count parameters
                	SELECT @countParamList = '@xName nvarchar(250),
                		@xPriceFrom float,
                		@xPriceTo float,
                		@xIsAvailable bit,
                		@xTotalDisplay int output';

                	-- Executing count sql
                	exec sp_executesql @countSql, @countParamList,
                		@Name,
                		@PriceFrom,
                		@PriceTo,
                		@IsAvailable,
                		@xTotalDisplay = @TotalDisplay output;

                	-- Preparing sql parameters
                	SELECT @paramList = '@xName nvarchar(250),
                		@xPriceFrom float,
                		@xPriceTo float,
                		@xIsAvailable bit,
                		@xPageIndex int,
                		@xPageSize int';

                	-- Executing sql
                	exec sp_executesql @sql, @paramList,
                		@Name,
                		@PriceFrom,
                		@PriceTo,
                		@IsAvailable,
                		@PageIndex,
                		@PageSize

                	print @countSql;
                	print @sql;

                END
                GO
                """;
            migrationBuilder.Sql(sql);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = "DROP PROCEDURE [dbo].[GetProducts]"; 
            migrationBuilder.Sql(sql);
        }
    }
}
