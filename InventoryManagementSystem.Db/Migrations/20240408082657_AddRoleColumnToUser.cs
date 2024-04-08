using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryManagementSystem.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleColumnToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$OE3EfWVFwUVI/a2sn.c/rukbV7vsRutAQ/DUA15dSYjt4u8tiHUvG", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$JwpBhE0g6mouTilwuBvg2ena/qeijqz6QgdPb8lYYIIDCc7kA60gm", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$dSgppSZyE3hTBcx0w9oKp.FGcxYcHeDWjILs3iJ/8wgikX6v4Q99.", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$GrohEq30A5eFk2i.rYzQmuWdmuNvB3saBwK..FVnyBTBZ8867P0Pm", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$illGJHqhqPWWpVuCzUOyXO65MAwSB1aDqwSu5LbtJlnl3cJDK2.Ju", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$zlUwH5SkPcfktfUxrIuJCumKE.gsw3EIxNeiAcF28HYGxGxxutbuO", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$x5yiNkHkKNRyFwc1tUj8M.dNvgc6oXQ4CmouW7uSVF.GTxI6ICma.", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$iaC4jY69YPnnrNbZakm5N./bmHADf.b0ssQp84.o0xbG0W3Tichdi", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$4ECOPTkDIyLlF4WyeUOfJupqRHRAkTKWJMfblgGer1oUYQy1xtYiO", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$Pn7lkZjQbIt82aZzwyBJk.L8n4nCyEC6e2mr/hF7rIiyAZf5CvYla", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 11,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$Ac.1kMG6h.yffR1eWNfUY.j3ZPi6kfk694k/p89y1ntLSaT5iRLvW", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 12,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$hhWUFwITOVZYlylPtwPdNeNp3ItIrtFqibFGmisX0pwdiuOnBKLhO", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 13,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$14I01jrKO3cQemc0HnBCQeZOgJYhWqU8ChaI6nrc4Ajd/oF.ScU.K", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 14,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$yJrBmNKtfM9K88ARJhmGvO3HHfxHHFoxxCJCr1bVbBgaTnV.IHzmC", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 15,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$Nc4n74MZtnSnGa6nEolMye9wB0ulzQuaTOxwj8HypF3JZkN7WuMmG", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 16,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$vHiOJZQfZRiIDbFqB7InguAGm2Ds6shFVcUdDVYYOtrX0DvOmaQvy", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 17,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$u8RH.xYFUHoxBupDzDW0Wu0vEHRPxFspzwLDP1w.9cfZTthWBFI7e", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$uhsfPHkW4y34jkNVC8UhyOB4Al0UnPiuhcGCyxNjJg.u4y2GDAzY.", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$rIEz2dkhN8J4PtVjHGL68OZwvA/5STigm1ftGZ7mI8n5JWhAsU0c2", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$OnxIr2pUxnhTcuC59BdcD.sLFp2ap8P9W5p5/L1/ITQEMsF32GhYe", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$bVDRlZfgl3s52JyKkPDlBeHClh79iKCRKpI4XJr8h6ppoQwwqiPf.", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 22,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$Vj/CAxNc4ovpXdahO0mOI.0igLo50ESbiwXrw5hyWvUMWSQqr0c7y", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 23,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$OOa4jp2s4aQeVis0Fly2pefS9UDLJuLEsRPWul6ljqv7jaWtddFCC", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 24,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$7NI.8Ziz9MXpMcq/gBs9f.ZfSAu7bC6/qXeTcb9.oNDQv13Y5qgR2", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 25,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$P7vKcFCteCcpT6JzFc3y4OR8H6flmGs5GvQ2PRFh8xCJ/sevA90P6", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 26,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$BDirTnZK.lLRRaTzZYpRVubH6WVwU.zOrdgGd8KU.0jK25pRIxXj6", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 27,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$u5qJM90SLMDPPqgAGZC2peSXhMDv5F/YRWnArAX/oroI2vAZ01YnO", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 28,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$7SwesXhRljBaY7gUEMhYBu1zegIg6WH1LXbkHhmUk9urT.8tkpeyO", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 29,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$ZCvsTkmPC5/nE3ukKqsb6uO5GNVheVqpSzCUqCqS5hJj7LWUeGc36", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 30,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$ZlJ/sVQ9y8QE0FOK3QhPYu7zrAjgGTNZuXnWO7Nc5mwirxtc9QKRa", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 31,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$SPBBvQfUk9L4jZ6/WHmfeuMI3D.788JK2VTmRieVBFKieMg07I91e", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 32,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$yDXsnX0CjtNum.Tto5RYJ.MgOWPMZ82eivL292NpyTUZhIbPYFVNy", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 33,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$O3iz/Cc37qI8RuNT6R58kOQGisOFUfxTw/lAA5vRiaeMnDvDhRmtO", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 34,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$JwboA75ynlvsK7FdgGvKeOxtiPU5SG7AG3xTh/8OAFi0Fc/7dQ6T2", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 35,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$s0tqgaLPPodVmRsIFK1Mu.7KkCQ.AThIOMX8z8i.IK/asUp6m17z2", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 36,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$7mtRwj/21ZY0pF/VGh.GIeeEWTeDN7yKyi2gmDP8SPhr0rrgQ2.46", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 37,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$Qp.c8XQdv3IUDGAjRP8WMuuVxZhrOWfvyY9riO8aICE2WOCydL.ii", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 38,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$jNXjvXpyCyaNyugovdG/VOW/0IvgGbjR.v4FNUwcCh9E8KCCXYIoi", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 39,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$ticcliD1qsWLZ4WHp2KhOOLCSGN2CQfXVZbgYXI4t7BaSIy9gB75m", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 40,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$0oigwFAVoyeP8CiKWa08HuYCSvzUbiPg6eyA.nqH1nUkyibWXv9Qu", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 41,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$DRYDCCIvX54qUIHEuwgjj.e.RbpOwyKOTX6zQ1yiU79yInCI2b3Qi", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 42,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$DljAHdDIhBlCkmC57a2ytu0hygZrsFjwMrKMcrDhKRvbK.RYdhSxa", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 43,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$ezk9zSYXgF8/lOdLf/2KBuLzHl.bgh8Xa.WFWX/WV77HtEFbR3T.W", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 44,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$yCOEDpRza3csrjQQ9s3SoeEGqs8XblRRtHMK0rd3x63JDNJD4Adbe", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 45,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$l0CokZpJ8t3PsHpz302r6.SeX/DIrcPFbkGU.G0ZXYb7XndVpOZWi", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 46,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$c2qNsaZL2FiFHol5MrJriupjCKk///KJnKrIx3/ka19AKv567U80.", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 47,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$vJ8PboIZVH7HYpD8tpXMj.1w2Vunng8ivvrIDq5.BzCgl5D5BLEEK", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 48,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$IcvZMNCeGiUBJKD0GmqJbOU69uX3/.XlDeejUQhhwjCQhP8E4ZTcq", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 49,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$SfhT21Ua7yjqHCp.mD96zO7p40hgg4H76/6.yWeoCidLqDj/oobHu", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 50,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$Lx4irD.OnGi8TCOItxIUau2goaLxffmqhdeDx0o/J2MiGJRY7dTaK", 0 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 100, "admin1@example.com", "$2a$11$G9RzLZRZtPyDPUuODbem1emfRQxxLAj/.URBaKZCGhMZY2cDpVz4C", 1, "admin1" },
                    { 200, "admin2@example.com", "$2a$11$4RdXLuldsfInZFG2uoKiPOa8/xbUlwiD9Ff1r27Wqq2slqZVI1zkG", 1, "admin2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 200);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$yahCOxMg6Rwv7NYWhCS1GOJBq2tk3HGOWvkWt2spsyva0KpK3j3CG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$YY381W06BNlpt3rU/on4CunDQjjD9MwD.YqYhvBzkUxH4N76qbgTy");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$d6s76qB5SOwxWLjQ.xfV2OMHGYtRGT9Uo52ZZvB.gQiCnyeUFhM4u");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$oNLEjuRPg0IxVAi9ZlbDseJ7HWva0EHLBa2GDG1b9QletYBGqmBeC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$JyK1EIpy5TlgkfnpRBXL2uNYoNO7054Yw8SEVQbBEjR.vjltVJAUG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$Nk17MqR0b3Xy59Hio1.nqOKu8y74JvI8tiGikVtQg0cPBHsgKiGZG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$5GRznd0kdTlt2P3zVn7B8.ovFv2FP09BqBUBODC7zbHmjLv8kbudq");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$HMuhTUxaNH7pEPFKkYoeTeNflRZALJtZK0f3SG3Y17IIu3ZbsJMKC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$6y1bNprzthgUGx15M7dsqOTFKMFB2gjvWqeW1fQLBbiDbjLZq7IXS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$n/HsY0ROmMh1lY7NcqvYYu4HMH0ZjWTif1hj5fmhWcHNwqRLjy1Q6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$UW2mRYaxWCRGo5MC3MXaTOsSI.9xtWn8uZcC/hskoUTJYZpEnVIWq");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$rGASBo/h9dGhFWCL7wQlAuKh59FfrZzC0/vYFW2Mp5WOUGrXdlkdW");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$YXN.tOYdO2TFrF2qxvN8FOF93QkzqkGkDX9ZCJW24HdbBV/wBZ.SG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$ocfn6J5zQwXdKwcH6HPso.Y9JujDvdUH/T5K5VNU6VKJrxuzvaXA6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$DECJGnmm0F/97PekbQuTv.li7RLcPg4NRaZaTJZf8uzRpxOL7.NDy");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$SbV/GuevY6RPzI/8geiIwutC88vIQeH4R5UsUg6t/pjL7QmCEAW0W");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$KiDaiCW8yAZZdKrQQ.B2veBHUjWikhYgr/N5o7cvJ9etc/MbSqYNW");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 18,
                column: "Password",
                value: "$2a$11$9JfVgE3Mv3Y0INWZ3AFN/ukG3K1J.3QB9cKpOoa1L3ivovtZ.mOla");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 19,
                column: "Password",
                value: "$2a$11$DQnGH5wwxiOJPXur2ST54u13WovBdpvS32WQ845YipS37zHVS2GHq");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 20,
                column: "Password",
                value: "$2a$11$94p7QIVaOkoJ0XuBz4nEOuB5oxvcBTwN2uYEYRIMZPVFn8O9QJ7SG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 21,
                column: "Password",
                value: "$2a$11$khF986iNnhiHGZP/9j0OyOGMnL3oLSCfH2OCYbqSFHCteRwaKARGW");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 22,
                column: "Password",
                value: "$2a$11$WHKD05V96T5ntqqcCHWl0exy/GMi1LRn8zdL6dGxhpI4ZR43Uh3fu");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 23,
                column: "Password",
                value: "$2a$11$m1DBACOvT/.xxNxSNEtT2u6gkVRebmNeYDcRIJj5Coizvv/JqEfvC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 24,
                column: "Password",
                value: "$2a$11$apwQorJwP6qH.fFVnk9PvOFNMm3Wy/8KiWx71A.bSeIOOlW8ZjhFC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 25,
                column: "Password",
                value: "$2a$11$4yg2XIt4nyJNkxArdAIr8ef.60WrI3qKl2JxZQowUkDh6kGg5jD2.");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 26,
                column: "Password",
                value: "$2a$11$8U6hzveO6oN08HR6PSdFaOrpXDmxQfWW/jY1qc8n4Q.YppeUqpGsO");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 27,
                column: "Password",
                value: "$2a$11$JfPW/hsXjVzrVYRrW.nvAuUgvYnhuLjBeJDKSUDVa1kyCmuux0P8e");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 28,
                column: "Password",
                value: "$2a$11$.SX7Sxip7BnjIP.QdFlbdeOp8d6MTilDQQbKAf3b/tJUEnxdoK0ii");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 29,
                column: "Password",
                value: "$2a$11$Sdgxh3gANiHUb98XkBgGauZNClpBsSzKQjMqVmA3dPYdJtirjfG2G");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 30,
                column: "Password",
                value: "$2a$11$qhU1nFUPr8FElz/YTEAL5uIcB28zt1JBM7zjtgTz7Sd4TyVEguBhu");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 31,
                column: "Password",
                value: "$2a$11$zXCx.VrJMzJws5ocCbEeHeatUo/uKK0rAY9VantOIdMJbtqr7waie");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 32,
                column: "Password",
                value: "$2a$11$R5pBGMBzsz2WsMAvTBIOAuEoUDhYgLD/79QEuHF60O13vjg7GM1AC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 33,
                column: "Password",
                value: "$2a$11$NemJw4/P.1Aah1ZtpuzNxOW96vu/c/eu9xZvtU9ZeynNh5x7zHUUS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 34,
                column: "Password",
                value: "$2a$11$mjyL00CZYUNEQJHzXN2QGeooWlhxFMurPNhU8VkeExYXeuI5O4Mra");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 35,
                column: "Password",
                value: "$2a$11$UTcQUf2UaXpKcNYpDjatK.dMq/FyY2CWHuwrwn9RVTAcMVg2HgiD.");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 36,
                column: "Password",
                value: "$2a$11$ZEN7x3fk9HJazF1X8epFBuDVAX5/aUr9vgNFyPLLPfRuNKigTQ8Ou");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 37,
                column: "Password",
                value: "$2a$11$jkvdINT5nJvH7i/fcbqhsOCBAbGRaZvmDwMFBwRURTdfrJB6UCxES");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 38,
                column: "Password",
                value: "$2a$11$jhA9QiMo28s.eUPHfBKp3elE.v98QI6tttODyXhGDIo8WDMaXaWka");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 39,
                column: "Password",
                value: "$2a$11$Em3/IPqO.zAM26AM8ypWPudkmvFTAYMsjHVM.7D6SFp29WPsGnQxi");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 40,
                column: "Password",
                value: "$2a$11$l7uAIGnVsCjTcvPR9j6Tqeu9ZaKzv72yIHTPiHCaNGjqnwe7xu9Zy");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 41,
                column: "Password",
                value: "$2a$11$hPrR5Je9CJTkcn24BdNwYOLfsl9YCw6G3KZ50i3.eIDUoh6YDA/0m");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 42,
                column: "Password",
                value: "$2a$11$puAExtRaCU2O1d5vDk20W.PtAFgE3WL9YxyCOa130BTbqhBpPCnqG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 43,
                column: "Password",
                value: "$2a$11$ayPu5rmpQp1kcqBskiFix.OlGlm0xktGCQr3xAjFTL8HGplZSI2qK");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 44,
                column: "Password",
                value: "$2a$11$kiM9I7QveNSgsvKHZcxSAeEhmz/.qBVniF0Z28OXeOpWVEYZl2kGq");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 45,
                column: "Password",
                value: "$2a$11$qcTlSFzYD7PSnJF.w3odmOCYHna2Hu3cM1tfC8hlh5hoRegW29Mly");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 46,
                column: "Password",
                value: "$2a$11$.SnI66qr0CjSkeeqxpU.BOGTAOlyNUQj8pCT5JkxW5Dz69og/tHUi");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 47,
                column: "Password",
                value: "$2a$11$QhnGrg1pcEfjyLQBybSayeqz9DsEnST0CqJKkcWGhpZ/j8qNOcepS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 48,
                column: "Password",
                value: "$2a$11$FX9YaKPa6meJkp9.ohp71O0kRgoWkYtoPKyHe8wiZDzFW3JiPZC.O");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 49,
                column: "Password",
                value: "$2a$11$Fx397PQsypLPPvt3awfIK.klz.Jv.Vom8UQF2oQDtvjTxfOHjjpLG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 50,
                column: "Password",
                value: "$2a$11$Dg8ZuJnwG0Tl8/IKGgA8..6RKx0mU7NECJjJUjPr3rme4MpTRJoLy");
        }
    }
}
