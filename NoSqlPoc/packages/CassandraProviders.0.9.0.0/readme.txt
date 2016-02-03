Example of Web.config file.
You can find information on https://cassandraaspproviders.codeplex.com/.

<?xml version="1.0" encoding="UTF-8"?>

<configuration>
  <appSettings>
    <!-- A static key is used instead of machiekey to encrypt passwords since machinekey changes when in development -->
    <add key="StaticKey" value="7862520A3D5D9B045B4C408034564A794DB25CA89DE62168764FF0DCE537184F0535D5D9AD66DEDC97DC1ABFF7FA540B4DFD82E5BB196B95D15FF81F75AD5328" />

    <!-- This is the e-mail address that will be the sender on all the e-mails sent by this application -->
    <add key="fromEmail" value="cassandraprovider@gmail.com" />

    <!-- By default a administrator user is made and this is its sign in name. Only low letters-->
    <add key="AdminName" value="admin" />

    <!-- By default a administrator user is made and this is its e-mail -->
    <add key="AdminEmail" value="ad@example.com" />

    <!-- By default a administrator user is made and this is its password -->
    <add key="AdminPassword" value="cassandra2014" />

    <!-- By default a administrator user is made and this is its password retrieval question -->
    <add key="AdminQuestion" value="Color of my first car?" />

    <!-- By default a administrator user is made and this is its password retrieval answer -->
    <add key="AdminAnswer" value="Kiwi" />

    <!-- By default a role is created to hold administrators and this is its name. Admin is added to this by default. -->
    <add key="AdminRoleName" value="Admins" />

    <!-- The name of your application -->
    <add key="ApplicationName" value="MyApp1" />

    <add key="ConnectionString" value="localhost" />

    <add key="UserIsOnlineTimeWindow" value="900" />

    <add key="ReplicationFactor" value="3" />

    <add key="UserIsActiveTimeWindow"  value="9000" />
  </appSettings>

  <system.web>
    <compilation debug="true" targetFramework="4.0" />

    <authentication mode="Forms">
      <forms loginUrl="~/Account/Login.aspx" timeout="2880" />
    </authentication>

    <!-- Custom membership provider -->

    <membership defaultProvider="CassandraMembershipProvider">
      <providers>
        <clear />
        <add name="CassandraMembershipProvider"
             type="Cognitum.CassandraProviders.Cassandra.CassandraMembershipProvider"
             enablePasswordRetrieval="true"
             enablePasswordReset="true"
             requiresQuestionAndAnswer="true"
             requiresUniqueEmail="true"
             maxInvalidPasswordAttempts="5"
             minRequiredPasswordLength="6"
             minRequiredNonalphanumericCharacters="0"
             passwordAttemptWindow="10"
             applicationName="MyApp1" />
      </providers>
    </membership>

    <!-- Custom profile provider -->

    <profile enabled="true" defaultProvider="CassandraProfileProvider">
      <providers>
        <clear />
        <add name="CassandraProfileProvider"
             type="Cognitum.CassandraProviders.Cassandra.CassandraProfileProvider"
             applicationName="MyApp1" />
      </providers>
      <properties>
        <clear />
        <add name="Gender" type="System.Int32" defaultValue="-1" />
        <add name="Birthdate" type="System.DateTime" defaultValue="-1" />
        <add name="PortraitBlobAddressUri" type="System.String" defaultValue="" />
      </properties>
    </profile>

    <!-- Custom role provider -->

    <roleManager enabled="true" defaultProvider="CassandraRoleProvider">
      <providers>
        <clear />
        <add name="CassandraRoleProvider"
             type="Cognitum.CassandraProviders.Cassandra.CassandraRoleProvider"
             applicationName="MyApp1" />
      </providers>
    </roleManager>

    <machineKey decryption="AES" decryptionKey="0CA3EFAF0F7A5E7A62681C0BF656EE0ECE31ACEE3E1023BA3FAD20EA5F199DE8" validation="SHA1" validationKey="448396CF27E32841EB374CF1D787713ABF42A2049DE62168764FF0DCE537184F0535D5D9AD66DEDC97DC1ABFF7FA540B4DFD82E5BB196B95D15FF81F75AD5328"></machineKey>

    <!-- Custom session state provider -->

    <sessionState timeout="60" cookieName="MyApp1" mode="Custom" customProvider="CassandraSessionProvider">
      <providers>
        <clear />
        <add name="CassandraSessionProvider" type="Cognitum.CassandraProviders.Cassandra.CassandraSessionStateProvider" />
      </providers>
    </sessionState>
  </system.web>

  <system.webServer>
    <modules runAllManagedModulesForAllRequests="true" />
  </system.webServer>
</configuration>