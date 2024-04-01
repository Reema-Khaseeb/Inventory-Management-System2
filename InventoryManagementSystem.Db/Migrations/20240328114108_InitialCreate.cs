using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryManagementSystem.Db.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { 3, "user3@example.com", "$2a$11$v2ohyb/Pa2SqQ1AHRjx/jeFmAjAZF0mWJqfgDv4GGJqeUtVXdiCgK", "user3" },
                    { 4, "user4@example.com", "$2a$11$oqU9RI/GxktCGBlDylYuOuVnbvwSDYCga6DxEu37RwMIEtzqF3ZF.", "user4" },
                    { 5, "user5@example.com", "$2a$11$9K9KGJ2QC/lvWcacU7LEpu6tVubGpxSgu0QBjDX3QtV6mX4PFB/EG", "user5" },
                    { 6, "user6@example.com", "$2a$11$gDobJ882oWFCJ.eszegF4u96QI72v.Qyda1J29MVGR.KrIGN8AgVO", "user6" },
                    { 7, "user7@example.com", "$2a$11$ST0FEcrQgEMYTzL3IS2EY.KMUJMxhAEpbGlaYz8te0T1kpNqdkCQ.", "user7" },
                    { 8, "user8@example.com", "$2a$11$pGCO.Za5VplhFoWhmRGgq.A5IM7wLv.YZKvTJ23Dh98n2QPc1DHU.", "user8" },
                    { 9, "user9@example.com", "$2a$11$Fwy2ZDkdkPbM5vzXYMt82eJp4lmle7X1a7H/TFGtK/qy8of7usm4q", "user9" },
                    { 10, "user10@example.com", "$2a$11$rZgP0JGxyav4wNt.9i3o6e0tVKfg8hyqreBBiUP4uj02yeSxz7viK", "user10" },
                    { 11, "user11@example.com", "$2a$11$n2uktkQFl7OVHQHHx09rKu/tlovwODAkTa3QxcOso0p6bKStETz5e", "user11" },
                    { 12, "user12@example.com", "$2a$11$XtxlATEqsTgGcp9OsprblOY.jtSOjl7SmVU40UDXB0DAMuKQNUYUW", "user12" },
                    { 13, "user13@example.com", "$2a$11$4e2kqN3VRkpuGPongyevHe7klYckuFaQugn7k952BOYTvyBOe.hPq", "user13" },
                    { 14, "user14@example.com", "$2a$11$PMW5ARCslliSlTOFRD8uLeUOCKChEaWBApA5sm61nqibNoSCdQ5zG", "user14" },
                    { 15, "user15@example.com", "$2a$11$JmMOhJOW0OrPxpuZPzHvoOXyoOLtD./Rq7bzluU85F8cPuAFTE9.G", "user15" },
                    { 16, "user16@example.com", "$2a$11$jEB8strCMEDrgYuHKZL0S.RW/UHdONYw0no/bqJqQGVi3BPny4aYq", "user16" },
                    { 17, "user17@example.com", "$2a$11$36TsLIg6C/9W62AWCvm9puZIvvNqLTf7UpU0IIp4eEb1epnhRIFTu", "user17" },
                    { 18, "user18@example.com", "$2a$11$6HZSxVPmBr489eROq5DpuuwQoHHLt6Nt.8IjNkpLg6IuHGQccr9rq", "user18" },
                    { 19, "user19@example.com", "$2a$11$BHOlpJTPzSczITFO.emxQ.EHaNp7AVahITMN8t8UPykgX.QemwkAe", "user19" },
                    { 20, "user20@example.com", "$2a$11$N8UfyNu/yiMrxBPlsKxvfumkcoyM2ouUrTpf4Dv.BcJGcOf3cin/.", "user20" },
                    { 21, "user21@example.com", "$2a$11$oGs32T2/TJQh7XTJsoPDLuSawNTXi2GTIS3REgBUPU/pZ/3nU7J1i", "user21" },
                    { 22, "user22@example.com", "$2a$11$5y2uR9KfCbO15YmRaGA8zOvl35fS/w4EtPzAjm8Z5kam4qVEt4OiC", "user22" },
                    { 23, "user23@example.com", "$2a$11$YxbJzleav61gWVmgHTSLweuL5ZoFOxEpFX7wV93BjO2rXJ8EF6D/6", "user23" },
                    { 24, "user24@example.com", "$2a$11$2e1sqj.npsTPbLjMOKnMyeAbbDEpn3v8XgIbYotyZ3fhwKzbvXINS", "user24" },
                    { 25, "user25@example.com", "$2a$11$fAilhsGs/WZhxwiI18R9Cu4v3/Z.T6r1mfc9yNKAsVHgkR8ZlBajK", "user25" },
                    { 26, "user26@example.com", "$2a$11$0qmfM4dn3G3965v6CzsGG.aG6YWGNWx5g52/K8FmSK6YJryA.G4Qu", "user26" },
                    { 27, "user27@example.com", "$2a$11$PV1AqFX4OH/yVHiUuJsHu.7RqU14uswm23ucv4S4JkFsoZ6dOyM6a", "user27" },
                    { 28, "user28@example.com", "$2a$11$AcFz0VvRba0VidyhR/I5ju7dYMkUL/wDdDLaDF4K6BjbSceLZXnBi", "user28" },
                    { 29, "user29@example.com", "$2a$11$p3Hynr0xkPJPLJkmCF42O.Je7ug/bjQNlkRtRD4IsE.HJDKtYgt6i", "user29" },
                    { 30, "user30@example.com", "$2a$11$Q0MTlJ.hNB7BbfU5aZ9ol.UdEqhX8tHkqCUcYROlqCDFUB0r5LKvu", "user30" },
                    { 31, "user31@example.com", "$2a$11$4IDszYAlhuj33PdS85WWQ.JqVa3NIyBSjLTqkygdev5cBzzmgLtKy", "user31" },
                    { 32, "user32@example.com", "$2a$11$zf.MMQzpW.0Bf1Y.AGTXduFGNHkgwWp/G1CUO3oS8wQ1CbPYBOwWW", "user32" },
                    { 33, "user33@example.com", "$2a$11$qRjcOgISoPHKWKjKyA84FO62MYOwFstxhefFqJKT24rrNxKsRQrc2", "user33" },
                    { 34, "user34@example.com", "$2a$11$f/4whBQ3RSQWLc5IH6YrbOO8rQmhreWbQoZDRW6034WcpLJK8nNHO", "user34" },
                    { 35, "user35@example.com", "$2a$11$4UBT4rxnU9faFekvtnsE5e5LPUqWp5pKxo/.vr.5tqeFZkpf5HWU.", "user35" },
                    { 36, "user36@example.com", "$2a$11$x39/wluAjyiYqS2NZaBdsuREUu/BFZID.N3jdnN/L5QOuEg1TuTdK", "user36" },
                    { 37, "user37@example.com", "$2a$11$4kdoIiOakyX2mo65LGZ82OaFVQLHdyC3bUMtv.Q7Nv2oMZo6WpPvm", "user37" },
                    { 38, "user38@example.com", "$2a$11$askML/3o7AiQXS7uk3GMy.1wCsrO8H1wecc/KsytGqNNCKL/oriI2", "user38" },
                    { 39, "user39@example.com", "$2a$11$fakivwGVcJ5.l03OZtR82u7GvlHXKNW9zsUuJKuME4QoeQag.ctA.", "user39" },
                    { 40, "user40@example.com", "$2a$11$Z0KgsrQ9aWptC14THW4/suRWngIu2HAJ58WRfLALZCkmdFi68h7qW", "user40" },
                    { 41, "user41@example.com", "$2a$11$yehScc5r7btox7rKmR909eDvyl5Cj2KvayzmvdJPCJuUgKw62u8Y2", "user41" },
                    { 42, "user42@example.com", "$2a$11$vjqptpMv1gdN8txAarlcZuEuQSuEL2Q4pPsAoQJKeocgya1MTTcgm", "user42" },
                    { 43, "user43@example.com", "$2a$11$fYNQ.IETmcL5WcxvU0ymru2JbLlL1595oLHijAMmyE6Bg4itFYCaO", "user43" },
                    { 44, "user44@example.com", "$2a$11$Dp5ARF/wrarTUmlxQiGt0e6A3Gwnqm3DRwW700ByUJxNVfChFPXAG", "user44" },
                    { 45, "user45@example.com", "$2a$11$uuVQab4xu24wTJrJQLuBDOV6pGM.MLoPSDo46cwAAfA9lRymFmFpS", "user45" },
                    { 46, "user46@example.com", "$2a$11$sRTSDdh.zBEHrEfEI5frPuQUxWl40pD3yaGFgjj1VFdMXPlUrPkPu", "user46" },
                    { 47, "user47@example.com", "$2a$11$g21UMf4o1ohaLtrcpUnMhe/xs.mh4gGDr1CTd7rN5J02sMfri.QlW", "user47" },
                    { 48, "user48@example.com", "$2a$11$OkRzkKrbGp7FXVpn5Qpf0uqyFWFhfUJ/b6GWaq3jMGt.795wT9DpK", "user48" },
                    { 49, "user49@example.com", "$2a$11$5V..j6VFtbgANYZDhCZn.ujjPwk8.66CuZbyxq0V72kfrAugXfc6C", "user49" },
                    { 50, "user50@example.com", "$2a$11$tek2nQBEu8zHiibIc9izY.ke1DwFLUHW0tq5Kw5z79QkD/XAprRIG", "user50" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
