Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.Windows.Forms
Imports System.Threading.Tasks
Imports System.Net.Sockets

Namespace SQLInstances

    Public Class EditServerDataAccess
        Public Property ConnectionString() As String
        Public Property conn() As SqlConnection
        Public Property LastError() As String
        Public Delegate Sub SqlInfoMessageEventHandler(Message As String)
        Public Event SQLInfoMessage As SqlInfoMessageEventHandler
        Public Delegate Sub SQLStateChangeHandler(State As System.Data.ConnectionState)
        Public Event SQLStateChanged As SQLStateChangeHandler


        Public Shared Function SearchServerInstance(ServerInfo As ServerInstance) As DataSet
            Dim appdefaults As New My.MySettings()
            Dim sDBserver As String = appdefaults.dbserver.ToString()
            Dim sDatabase As String = appdefaults.databasename.ToString()
            Dim sUser As String = appdefaults.login.ToString()
            Dim sPassword As String = appdefaults.password.ToString()
            Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
            con.Open()
            Dim cmd As New SqlCommand("SELECT * FROM [SDODB_ServerEvidence].[dbo].[SDODB_Servers] WHERE [SERVERNAME] LIKE @SERVERServerName ORDER BY [SERVERNAME]", con)
            cmd.Parameters.AddWithValue("@SERVERServerName", SqlDbType.VarChar).Value = If(DirectCast(ServerInfo.SERVERservername, Object), "%")
            Dim sda As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            sda.Fill(ds)
            cmd.ExecuteNonQuery()
            con.Close()
            Return ds
        End Function

        Public Function SelectSingleRecord(ServerInfo As ServerInstance) As DataRow
            Dim appdefaults As New My.MySettings()
            Dim sDBserver As String = appdefaults.dbserver.ToString()
            Dim sDatabase As String = appdefaults.databasename.ToString()
            Dim sUser As String = appdefaults.login.ToString()
            Dim sPassword As String = appdefaults.password.ToString()
            Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
            con.Open()
            Dim cmd As New SqlCommand("SELECT * FROM [SDODB_ServerEvidence].[dbo].[SDODB_Servers] WHERE [ID] = @SERVERserverID", con)
            cmd.Parameters.AddWithValue("@SERVERserverID", SqlDbType.Int).Value = If(DirectCast(ServerInfo.SERVERserverID, Object), 0)
            Dim sda As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            sda.Fill(ds)
            cmd.ExecuteNonQuery()
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In ds.Tables(0).Rows
                    Return row
                Next
            End If
            con.Close()
            Return Nothing
        End Function
    
        Public Function UpdateServerInstanceTable(SQLInfo As ServerInstance) As String
            Dim appdefaults As New My.MySettings()
            Dim sDBserver As String = appdefaults.dbserver.ToString()
            Dim sDatabase As String = appdefaults.databasename.ToString()
            Dim sUser As String = appdefaults.login.ToString()
            Dim sPassword As String = appdefaults.password.ToString()
            Dim Message As String
            Try
                Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
                con.Open()
                Dim cmd As New SqlCommand("UPDATE [SDODB_ServerEvidence].[dbo].[SDODB_Servers] SET [SERVERNAME] = @SERVERServerName,[SERVERIPADDRESS] = @SERVERSERVERIPADDRESS,[COUNTRY] = @SERVERCOUNTRY,[RESPONSIBILITY] = @SERVERRESPONSIBILITY,[STATUS] = @SERVERSTATUS,[LOCATION] = @SERVERLOCATION,[CRITICITY] = @SERVERCRITICITY,[NOTES] = @SERVERNOTES,[SDODBSCOPE] = @SERVERSDODBSCOPE,[MOMMONITORED] = @SERVERMOMMONITORED,[VIRTUAL] = @SERVERVIRTUAL,[SERVERCLUSTERED] = @SERVERSERVERCLUSTERED,[SERVERLANGUAGE] = @SERVERSERVERLANGUAGE,[SERVEROS] = @SERVERSERVEROS,[SERVEROSSP] = @SERVERSERVEROSSP,[OSARCHITECTURE] = @SERVEROSARCHITECTURE,[OSCPUCOUNT] = @SERVEROSCPUCOUNT,[OSLOGICALPROCESSORS] = @SERVEROSLOGICALPROCESSORS,[CPUFREQUENCY] = @SERVERCPUFREQUENCY,[SYSTEMMEMORYGB] = @SERVERSYSTEMMEMORYGB,[SERVEREDITION] = @SERVERSERVEREDITION,[VMWARE_CLUSTER] = @SERVERVMWARE_CLUSTER,[VMWARE_VIC] = @SERVERVMWARE_VIC WHERE [ID] = @SERVERserverID", con)
                cmd.Parameters.AddWithValue("@SERVERserverID", SQLInfo.SERVERserverID)
                cmd.Parameters.AddWithValue("@SERVERServerName", SQLInfo.SERVERservername)
                cmd.Parameters.AddWithValue("@SERVERserveripaddress", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SERVERserveripaddress, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SERVERcountry", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SERVERcountry, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@ServerRESPONSIBILITY", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SERVERresponsibility, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SERVERSTATUS", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SERVERstatus, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SERVERLOCATION", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SERVERlocation, Object), False)
                cmd.Parameters.AddWithValue("@SERVERCRITICITY", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SERVERcriticity, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SERVERNOTES", SqlDbType.Text).Value = If(DirectCast(SQLInfo.SERVERnotes, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SERVERSDODBSCOPE", SqlDbType.Bit).Value = If(DirectCast(SQLInfo.SERVERsdodbscope, Object), False)
                cmd.Parameters.AddWithValue("@SERVERMOMMONITORED", SqlDbType.Bit).Value = If(DirectCast(SQLInfo.SERVERmommonitored, Object), False)
                cmd.Parameters.AddWithValue("@SERVERVIRTUAL", SqlDbType.Bit).Value = If(DirectCast(SQLInfo.SERVERvirtual, Object), False)
                cmd.Parameters.AddWithValue("@SERVERSERVERCLUSTERED", SqlDbType.Bit).Value = If(DirectCast(SQLInfo.SERVERSERVERCLUSTERED, Object), False)
                cmd.Parameters.AddWithValue("@SERVERSERVEROS", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SERVERSERVEROS, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SERVERSERVERLANGUAGE", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SERVERSERVERLANGUAGE, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SERVERSERVEROSSP", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SERVERSERVEROSSP, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SERVEROSARCHITECTURE", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.ServerOSARCHITECTURE, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SERVEROSCPUCOUNT", SqlDbType.Int).Value = If(DirectCast(SQLInfo.SERVEROSCPUCOUNT, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SERVEROSLOGICALPROCESSORS", SqlDbType.Int).Value = If(DirectCast(SQLInfo.SERVEROSLOGICALPROCESSORS, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SERVERCPUFREQUENCY", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SERVERCPUFREQUENCY, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SERVERSYSTEMMEMORYGB", SqlDbType.Int).Value = If(DirectCast(SQLInfo.SERVERSYSTEMMEMORYGB, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SERVERSERVEREDITION", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SERVERSERVEREDITION, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SERVERVMWARE_CLUSTER", SqlDbType.NVarChar).Value = If(DirectCast(SQLInfo.SERVERVMWARE_CLUSTER, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SERVERVMWARE_VIC", SqlDbType.NVarChar).Value = If(DirectCast(SQLInfo.SERVERVMWARE_VIC, Object), DBNull.Value)
                cmd.ExecuteNonQuery()
                con.Close()
                'Message = "Successfully Updated!"
                'Return Message
                MessageBox.Show("record inserted Successfully", "Process Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                'Return ex.Message.ToString()
                MsgBox("ERROR" & vbLf & ex.Message)
            Catch ex As Exception
                'Return ex.Message.ToString()
                MsgBox("ERROR" & vbLf & ex.Message)
            End Try
        End Function


        Public Function InsertServer(SQLInfo As ServerInstance) As String
            Dim appdefaults As New My.MySettings()
            Dim sDBserver As String = appdefaults.dbserver.ToString()
            Dim sDatabase As String = appdefaults.databasename.ToString()
            Dim sUser As String = appdefaults.login.ToString()
            Dim sPassword As String = appdefaults.password.ToString()
            'Dim Message As String
            Try
                Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
                con.Open()
                Dim cmd As New SqlCommand("INSERT INTO [SDODB_ServerEvidence].[dbo].[SDODB_Servers] ([SERVERNAME] ,[SERVERIPADDRESS] ,[COUNTRY],[RESPONSIBILITY] ,[STATUS] ,[LOCATION] ,[CRITICITY] ,[NOTES] ,[SDODBSCOPE],[MOMMONITORED] ,[VIRTUAL] ,[SERVERCLUSTERED] ,[SERVERLANGUAGE] ,[SERVEROS] ,[SERVEROSSP] ,[OSARCHITECTURE] ,[OSCPUCOUNT] ,[OSLOGICALPROCESSORS],[CPUFREQUENCY],[SYSTEMMEMORYGB] ,[SERVEREDITION] ,[VMWARE_CLUSTER] ,[VMWARE_VIC]) VALUES (@SERVERSERVERNAME,@SERVERSERVERIPADDRESS,@SERVERCOUNTRY,@SERVERRESPONSIBILITY,@SERVERSTATUS, @SERVERLOCATION,@SERVERCRITICITY, @SERVERNOTES, @SERVERSDODBSCOPE,@SERVERMOMMONITORED, @SERVERVIRTUAL,@SERVERSERVERCLUSTERED, @SERVERSERVERLANGUAGE,@SERVERSERVEROS, @SERVERSERVEROSSP,@SERVEROSARCHITECTURE,@SERVEROSCPUCOUNT, @SERVEROSLOGICALPROCESSORS, @SERVERCPUFREQUENCY,@SERVERSYSTEMMEMORYGB, @SERVERSERVEREDITION,@SERVERVMWARE_CLUSTER, @SERVERVMWARE_VIC)", con)
                cmd.Parameters.AddWithValue("@SERVERServerName", SQLInfo.SERVERservername)
                cmd.Parameters.AddWithValue("@SERVERserveripaddress", SQLInfo.SERVERserveripaddress)
                cmd.Parameters.AddWithValue("@SERVERcountry", SQLInfo.SERVERcountry)
                cmd.Parameters.AddWithValue("@ServerRESPONSIBILITY", SQLInfo.SERVERresponsibility)
                cmd.Parameters.AddWithValue("@SERVERSTATUS", SQLInfo.SERVERstatus)
                cmd.Parameters.AddWithValue("@SERVERLOCATION", SQLInfo.SERVERlocation)
                cmd.Parameters.AddWithValue("@SERVERCRITICITY", SQLInfo.SERVERcriticity)
                cmd.Parameters.AddWithValue("@SERVERNOTES", SQLInfo.SERVERnotes)
                cmd.Parameters.AddWithValue("@SERVERSDODBSCOPE", SQLInfo.SERVERsdodbscope)
                cmd.Parameters.AddWithValue("@SERVERMOMMONITORED", SQLInfo.SERVERmommonitored)
                cmd.Parameters.AddWithValue("@SERVERVIRTUAL", SQLInfo.SERVERvirtual)
                cmd.Parameters.AddWithValue("@SERVERSERVERCLUSTERED", SQLInfo.SERVERSERVERCLUSTERED)
                cmd.Parameters.AddWithValue("@SERVERSERVEROS", SQLInfo.SERVERSERVEROS)
                cmd.Parameters.AddWithValue("@SERVERSERVERLANGUAGE", SQLInfo.SERVERSERVERLANGUAGE)
                cmd.Parameters.AddWithValue("@SERVERSERVEROSSP", SQLInfo.SERVERSERVEROSSP)
                cmd.Parameters.AddWithValue("@SERVEROSARCHITECTURE", SQLInfo.SERVEROSARCHITECTURE)
                cmd.Parameters.AddWithValue("@SERVEROSCPUCOUNT", SQLInfo.SERVEROSCPUCOUNT)
                cmd.Parameters.AddWithValue("@SERVEROSLOGICALPROCESSORS", SQLInfo.SERVEROSLOGICALPROCESSORS)
                cmd.Parameters.AddWithValue("@SERVERCPUFREQUENCY", SQLInfo.SERVERCPUFREQUENCY)
                cmd.Parameters.AddWithValue("@SERVERSYSTEMMEMORYGB", SQLInfo.SERVERSYSTEMMEMORYGB)
                cmd.Parameters.AddWithValue("@SERVERSERVEREDITION", SQLInfo.SERVERSERVEREDITION)
                cmd.Parameters.AddWithValue("@SERVERVMWARE_CLUSTER", SQLInfo.SERVERVMWARE_CLUSTER)
                cmd.Parameters.AddWithValue("@SERVERVMWARE_VIC", SQLInfo.SERVERVMWARE_VIC)
                Dim result As Integer = cmd.ExecuteNonQuery()
                If result >= 1 Then
                    'Message = SQLInfo.SERVERservername + "\\" + SQLInfo.SERVERservername + "Details inserted successfully"
                    MessageBox.Show("record inserted Successfully", "Process Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    'Message = SQLInfo.SERVERservername + "\\" + SQLInfo.SERVERservername + " Details not inserted successfully"
                    MessageBox.Show("Failed to insert record")
                End If
                con.Close()
                'Return Message

            Catch ex As SqlException
                'Message = "Error: " + ex.Message.ToString()
                MsgBox("ERROR" & vbLf & ex.Message)
                'Return Message

            Catch ex As Exception
                'Message = "Error : " + ex.Message
                MsgBox("ERROR" & vbLf & ex.Message)
                'Return Message

            End Try
        End Function



   
        Public Shared Function SearchDBInstance(ServerInfo As ServerInstance) As DataSet
            Dim appdefaults As New My.MySettings()
            Dim sDBserver As String = appdefaults.dbserver.ToString()
            Dim sDatabase As String = appdefaults.databasename.ToString()
            Dim sUser As String = appdefaults.login.ToString()
            Dim sPassword As String = appdefaults.password.ToString()
            Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
            con.Open()
            Dim cmd As New SqlCommand("SELECT [SERVERNAME],[db_name],[INSTANCENAME],[DBPRODUCTNAME],[COUNTRY],[db_created],[DBBACKUPSLOCATION] FROM [SDODB_ServerEvidence].[dbo].[usr_DatabasesInfo] WHERE [db_name] LIKE @SERVERdb_name ORDER BY [COUNTRY],[SERVERNAME] ASC", con)
            cmd.Parameters.AddWithValue("@SERVERdb_name", SqlDbType.VarChar).Value = If(DirectCast(ServerInfo.SERVERdb_name, Object), "%")
            Dim sda As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            sda.Fill(ds)
            cmd.ExecuteNonQuery()
            con.Close()

            Return ds
        End Function

        Public Function SelectSingleServerRecord(ServerInfo As ServerInstance) As DataRow
            Dim appdefaults As New My.MySettings()
            Dim sDBserver As String = appdefaults.dbserver.ToString()
            Dim sDatabase As String = appdefaults.databasename.ToString()
            Dim sUser As String = appdefaults.login.ToString()
            Dim sPassword As String = appdefaults.password.ToString()
            Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
            con.Open()
            Dim cmd As New SqlCommand("SELECT * FROM [SDODB_ServerEvidence].[dbo].[SDODB_Servers] WHERE [ServerName] = @SERVERserverName", con)
            cmd.Parameters.AddWithValue("@SERVERserverName", SqlDbType.VarChar).Value = If(DirectCast(ServerInfo.SERVERservername, Object), 0)
            Dim sda As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            sda.Fill(ds)
            cmd.ExecuteNonQuery()
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In ds.Tables(0).Rows
                    Return row
                Next
            End If
            con.Close()
            Return Nothing
        End Function


    End Class
End Namespace