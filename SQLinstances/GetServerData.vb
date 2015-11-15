Imports System.Data.SqlClient
Imports System
Imports System.Configuration
Public Class GetServerData
    Private connetionString As String
    Private connection As SqlConnection
    Private command As SqlCommand
    Private sql As String
    '--------------------------------
    Private command1 As SqlCommand
    Private sql1 As String
    '---------------------------------
    Private m_CPU As Integer
    Private m_SP As String
    Private m_memory As Integer
    Private m_VersionName As String
    '-----------------------------
    Private m_CPUMhz As Integer
    '---------------------------

    Private connection2 As SqlConnection
    Private command2 As SqlCommand
    Private sql2 As String
    '-------------------
    Private m_VIC As String
    Private m_VMHost As String
    Private m_SDEnumber As String
    '-----------------------------
    Private command3 As SqlCommand
    Private sql3 As String
    '------------------------------
    Private m_IP As String

    '----------------------------------
    Private command4 As SqlCommand
    Private sql4 As String
    '--------------------------
    Private m_country As String
    Private m_location As String


    Public Sub New()
        connetionString = "Data Source=DEUSDHEID0088;Initial Catalog=ServiceManager;Trusted_Connection=True"


        Try
            sql = "dbo.sp_HCGetOperatingSystemDetail"
            connection = New SqlConnection(connetionString)
            ' GetConnection is a method that creates and return the '
            ' SqlConnection used here according to your connection string'
            connection.Open()
            ' Create the command with the sproc name and add the parameter required'
            Dim Command As SqlCommand = New SqlCommand()
            Command = New SqlCommand(sql, connection)
            'command.CommandText = "UpdateDataInsideTable"
            Command.CommandType = CommandType.StoredProcedure
            Command.Parameters.AddWithValue("@Principal", EditSQLServers.tbSQLServerName_1.Text.ToString.Trim + ".grouphc.net")
            ' Ask the command to create an SqlDataReader on the result of the sproc'

            Dim sda As New SqlDataAdapter(Command)
            Dim ds As New DataSet()
            sda.Fill(ds)
            Command.ExecuteNonQuery()

            'Dim r As DataRow
            'LogicalProcessors = r.Item(0).ToString()
            'Next

            Using r = Command.ExecuteReader()
                ' If the SqlDataReader.Read returns true then there is a customer with that ID'
                If r.Read() Then


                    ' Get the first and second field frm the reader'
                    m_CPU = r.GetInt32(4)
                    m_SP = r.GetString(8)
                    m_memory = r.GetInt32(2) / 1024
                    m_VersionName = r.GetString(3)
                    'lblAddress.Text = r.GetString(1)
                End If
            End Using
            'command.ExecuteNonQuery()
            Command.Dispose()
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        '--------------------------------------------------------------------------------------
        Try
            sql1 = "dbo.sp_HCGetProcessorDetail"
            connection = New SqlConnection(connetionString)
            ' GetConnection is a method that creates and return the '
            ' SqlConnection used here according to your connection string'
            connection.Open()
            ' Create the command with the sproc name and add the parameter required'
            Dim Command1 As SqlCommand = New SqlCommand()
            Command1 = New SqlCommand(sql1, connection)
            'command.CommandText = "UpdateDataInsideTable"
            Command1.CommandType = CommandType.StoredProcedure
            Command1.Parameters.AddWithValue("@Principal", EditSQLServers.tbSQLServerName_1.Text.ToString.Trim + ".grouphc.net")
            ' Ask the command to create an SqlDataReader on the result of the sproc'

            Dim sda As New SqlDataAdapter(Command1)
            Dim ds As New DataSet()
            sda.Fill(ds)
            Command1.ExecuteNonQuery()

            'Dim r As DataRow
            'LogicalProcessors = r.Item(0).ToString()
            'Next

            Using r = Command1.ExecuteReader()
                ' If the SqlDataReader.Read returns true then there is a customer with that ID'
                If r.Read() Then


                    ' Get the first and second field frm the reader'
                    m_CPUMhz = r.GetInt32(7)

                    'lblAddress.Text = r.GetString(1)
                End If
            End Using
            'command.ExecuteNonQuery()
            Command1.Dispose()
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        '--------------------------------------------------------------------------------------


        Try

            sql2 = "dbo.sp_HCGetVMwareDetail"

            connection2 = New SqlConnection(connetionString)
            ' GetConnection is a method that creates and return the '
            ' SqlConnection used here according to your connection string'
            connection2.Open()
            ' Create the command with the sproc name and add the parameter required'
            Dim Command2 As SqlCommand = New SqlCommand()
            Command2 = New SqlCommand(sql2, connection2)
            'command.CommandText = "UpdateDataInsideTable"
            Command2.CommandType = CommandType.StoredProcedure
            Command2.Parameters.AddWithValue("@Principal", EditSQLServers.tbSQLServerName_1.Text.ToString.Trim + ".grouphc.net")
            ' Ask the command to create an SqlDataReader on the result of the sproc'

            Dim sda As New SqlDataAdapter(Command2)
            Dim ds As New DataSet()
            sda.Fill(ds)
            Command2.ExecuteNonQuery()

            'Dim r As DataRow
            'LogicalProcessors = r.Item(0).ToString()
            'Next

            Using r = Command2.ExecuteReader()
                ' If the SqlDataReader.Read returns true then there is a customer with that ID'
                If r.Read() Then


                    ' Get the first and second field frm the reader'
                    m_VIC = r.GetString(0)
                    m_VMHost = r.GetString(1)
                    m_SDEnumber = r.GetString(10)


                End If
            End Using
            'command.ExecuteNonQuery()
            Command2.Dispose()
            connection2.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        '---------------------------------------------------------------------
        Try
            sql3 = "dbo.sp_HCGetSolarWindsData"
            connection2 = New SqlConnection(connetionString)
            ' GetConnection is a method that creates and return the '
            ' SqlConnection used here according to your connection string'
            connection2.Open()
            ' Create the command with the sproc name and add the parameter required'
            Dim Command3 As SqlCommand = New SqlCommand()
            Command3 = New SqlCommand(sql3, connection2)
            'command.CommandText = "UpdateDataInsideTable"
            Command3.CommandType = CommandType.StoredProcedure
            Command3.Parameters.AddWithValue("@Server", EditSQLServers.tbSQLServerName_1.Text.ToString.Trim + ".grouphc.net")
            ' Ask the command to create an SqlDataReader on the result of the sproc'

            Dim sda As New SqlDataAdapter(Command3)
            Dim ds As New DataSet()
            sda.Fill(ds)
            Command3.ExecuteNonQuery()

            'Dim r As DataRow
            'LogicalProcessors = r.Item(0).ToString()
            'Next

            Using r = Command3.ExecuteReader()
                ' If the SqlDataReader.Read returns true then there is a customer with that ID'
                If r.Read() Then


                    ' Get the first and second field frm the reader'
                    m_IP = r.GetString(1)



                End If
            End Using
            'command.ExecuteNonQuery()
            Command3.Dispose()
            connection2.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        '--------------------------------------------------------------
        Try
            sql4 = "select * from dbo.v_ExtendedClassDisp where PrincipalName = @PrincipalName"
            connection2 = New SqlConnection(connetionString)
            ' GetConnection is a method that creates and return the '
            ' SqlConnection used here according to your connection string'
            connection2.Open()
            ' Create the command with the sproc name and add the parameter required'
            Dim Command4 As SqlCommand = New SqlCommand()
            Command4 = New SqlCommand(sql4, connection2)
            'command.CommandText = "UpdateDataInsideTable"
            'Command4.CommandType = CommandType.StoredProcedure
            Command4.Parameters.AddWithValue("@PrincipalName", EditSQLServers.tbSQLServerName_1.Text.ToString.Trim + ".grouphc.net")
            ' Ask the command to create an SqlDataReader on the result of the sproc'

            Dim sda As New SqlDataAdapter(Command4)
            Dim ds As New DataSet()
            sda.Fill(ds)
            Command4.ExecuteNonQuery()

            'Dim r As DataRow
            'LogicalProcessors = r.Item(0).ToString()
            'Next

            Using r = Command4.ExecuteReader()
                ' If the SqlDataReader.Read returns true then there is a customer with that ID'
                If r.Read() Then


                    ' Get the first and second field frm the reader'
                    m_country = r.GetString(23)
                    m_location = r.GetString(22)


                End If
            End Using
            'command.ExecuteNonQuery()
            Command4.Dispose()
            connection2.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub



    Public Property LogicalProcessors()
        Get
            LogicalProcessors = m_CPU
        End Get
        Set(value)

        End Set
    End Property

    Public Property ServicePackVersion()
        Get
            ServicePackVersion = m_SP
        End Get
        Set(value)

        End Set
    End Property
    Public Property PhysicalMemory()
        Get
            PhysicalMemory = m_Memory
        End Get
        Set(value)

        End Set
    End Property


    Public Property VersionName()
        Get
            VersionName = m_VersionName
        End Get
        Set(value)

        End Set
    End Property

    Public Property Mhz()
        Get
            Mhz = m_CPUMhz
        End Get
        Set(value)

        End Set
    End Property

    Public Property VIC()
        Get
            VIC = m_VIC
        End Get
        Set(value)

        End Set
    End Property
    Public Property VMHost()
        Get
            VMHost = m_VMHost
        End Get
        Set(value)

        End Set
    End Property

    Public Property SDEnumber()
        Get
            SDEnumber = m_SDENumber
        End Get
        Set(value)

        End Set
    End Property

    Public Property IP()
        Get
            IP = m_IP
        End Get
        Set(value)

        End Set
    End Property


    Public Property location()
        Get
            location = m_location
        End Get
        Set(value)

        End Set
    End Property

    Public Property country()
        Get
            country = m_country
        End Get
        Set(value)

        End Set
    End Property
End Class
