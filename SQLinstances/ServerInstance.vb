Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Namespace SQLInstances
    Public Class ServerInstance
        Private ServerID As Integer
        Private servername As String
        Private serveripaddress As String
        Private country As String
        Private responsibility As String
        Private status As String
        Private location As String
        Private criticity As String
        Private notes As String
        Private sdodbscope As Boolean
        Private mommonitored As Boolean
        Private virtual As Boolean
        Private SERVERCLUSTERED As Boolean
        Private SERVEROS As String
        Private SERVERLANGUAGE As String
        Private SERVEROSSP As String
        Private OSARCHITECTURE As String
        Private OSCPUCOUNT As String
        Private OSLOGICALPROCESSORS As String
        Private CPUFREQUENCY As String
        Private SYSTEMMEMORYGB As String
        Private SERVEREDITION As String
        Private VMWARE_CLUSTER As String
        Private VMWARE_VIC As String
        Private db_name As String


        Public Property SERVERserverID() As Integer
            Get
                Return ServerID
            End Get
            Set(value As Integer)
                ServerID = value
            End Set
        End Property


        Public Property SERVERservername() As String
            Get
                Return servername
            End Get
            Set(value As String)
                servername = value
            End Set
        End Property
        Public Property SERVERserveripaddress() As String
            Get
                Return serveripaddress
            End Get
            Set(value As String)
                serveripaddress = value
            End Set
        End Property

        Public Property SERVERcountry() As String
            Get
                Return country
            End Get
            Set(value As String)
                country = value
            End Set
        End Property

        Public Property SERVERresponsibility() As String
            Get
                Return responsibility
            End Get
            Set(value As String)
                responsibility = value
            End Set
        End Property
        Public Property SERVERstatus() As String
            Get
                Return status
            End Get
            Set(value As String)
                status = value
            End Set
        End Property

        Public Property SERVERlocation() As String
            Get
                Return location
            End Get
            Set(value As String)
                location = value
            End Set
        End Property
        Public Property SERVERcriticity() As String
            Get
                Return criticity
            End Get
            Set(value As String)
                criticity = value
            End Set
        End Property

        Public Property SERVERnotes() As String
            Get
                Return notes
            End Get
            Set(value As String)
                notes = value
            End Set
        End Property



        Public Property SERVERsdodbscope() As Boolean
            Get
                Return sdodbscope
            End Get
            Set(value As Boolean)
                sdodbscope = value
            End Set
        End Property


        Public Property SERVERmommonitored() As Boolean
            Get
                Return mommonitored
            End Get
            Set(value As Boolean)
                mommonitored = value
            End Set
        End Property


        Public Property SERVERvirtual() As Boolean
            Get
                Return virtual
            End Get
            Set(value As Boolean)
                virtual = value
            End Set
        End Property



        Public Property SERVERSERVERCLUSTERED() As Boolean
            Get
                Return SERVERCLUSTERED
            End Get
            Set(value As Boolean)
                SERVERCLUSTERED = value
            End Set
        End Property

        Public Property SERVERSERVEROS() As String
            Get
                Return SERVEROS
            End Get
            Set(value As String)
                SERVEROS = value
            End Set
        End Property
        Public Property SERVERSERVERLANGUAGE() As String
            Get
                Return SERVERLANGUAGE
            End Get
            Set(value As String)
                SERVERLANGUAGE = value
            End Set
        End Property


      


        Public Property SERVERSERVEROSSP() As String
            Get
                Return SERVEROSSP
            End Get
            Set(value As String)
                SERVEROSSP = value
            End Set
        End Property


        Public Property SERVEROSARCHITECTURE() As String
            Get
                Return OSARCHITECTURE
            End Get
            Set(value As String)
                OSARCHITECTURE = value
            End Set
        End Property



        Public Property SERVEROSCPUCOUNT() As String
            Get
                Return OSCPUCOUNT
            End Get
            Set(value As String)
                OSCPUCOUNT = value
            End Set
        End Property

        Public Property SERVEROSLOGICALPROCESSORS() As String
            Get
                Return OSLOGICALPROCESSORS
            End Get
            Set(value As String)
                OSLOGICALPROCESSORS = value
            End Set
        End Property


        Public Property SERVERCPUFREQUENCY() As String
            Get
                Return CPUFREQUENCY
            End Get
            Set(value As String)
                CPUFREQUENCY = value
            End Set
        End Property

        Public Property SERVERSYSTEMMEMORYGB() As String
            Get
                Return SYSTEMMEMORYGB
            End Get
            Set(value As String)
                SYSTEMMEMORYGB = value
            End Set
        End Property

        Public Property SERVERSERVEREDITION() As String
            Get
                Return SERVEREDITION
            End Get
            Set(value As String)
                SERVEREDITION = value
            End Set
        End Property

        Public Property SERVERVMWARE_CLUSTER() As String
            Get
                Return VMWARE_CLUSTER
            End Get
            Set(value As String)
                VMWARE_CLUSTER = value
            End Set
        End Property

        Public Property SERVERVMWARE_VIC() As String
            Get
                Return VMWARE_VIC
            End Get
            Set(value As String)
                VMWARE_VIC = value
            End Set
        End Property

        Public Property SERVERdb_name() As String
            Get
                Return db_name
            End Get
            Set(value As String)
                db_name = value
            End Set
        End Property

    End Class
End Namespace