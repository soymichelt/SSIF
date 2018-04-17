Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations

    Partial Public Class AddTableActivities
        Inherits DbMigration

        Public Overrides Sub Up()

            CreateTable(
                "dbo.tblActivities",
                Function(c) New With
                    {
                        .AcitivityId = c.Guid(nullable:=False),
                        .ActivityDate = c.DateTime(nullable:=False),
                        .Type = c.String(nullable:=False, maxLength:=10, unicode:=False),
                        .ActivityValue = c.String(nullable:=False, maxLength:=50, unicode:=False),
                        .OptionalMessage = c.String(),
                        .BusinessId = c.Guid(nullable:=False),
                        .UserId = c.Guid(nullable:=False),
                        .IsSended = c.Boolean(nullable:=False)
                    }) _
                .PrimaryKey(Function(t) t.AcitivityId)

        End Sub

        Public Overrides Sub Down()

            'DropForeignKey("dbo.tblAccessInRoles", "AccessId", "dbo.tblAccess")
            'DropIndex("dbo.tblAccessInRoles", New String() {"AccessId"})
            DropTable("dbo.tblActivities")

        End Sub

    End Class

End Namespace