Vue.component('sidebar', {
    data: function () {
        return {
            currentLocation: location.href,
            hrefs: {
                objects: 'Object_Type.html',
                role: 'role.html',
                role_det: 'role_detail.html',
                sec_object: 'sec_object.html',
                Allowed_Action: 'Allowed_Action.html'
            }
        }
    },
    mounted: function () {
        this.currentLocation = location.href
    },
    methods: {

    },
    template: `<nav class="navbar navbar-inverse" style=" ">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="#">Sistema de Gestion de Casos y Documentos </a>
    </div>
    <ul class="nav navbar-nav">
      <li ><a href="#">Principal</a></li>
      <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Casos <span class="caret"></span></a>
        <ul class="dropdown-menu">
          <li><a href="Cases.html">Crear Caso</a></li>
          <li><a href="Process.html">Crear Proceso</a></li>
          <li><a href="Process_Field.html">Crear Campos</a></li>
        </ul>
      <li><a href="#">Reportes</a></li>
      <li><a href="#">Auditoria</a></li>
      <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Mantenimiento <span class="caret"></span></a>
        <ul class="dropdown-menu">
          <li><a href="User.html">Usuarios</a></li>
          <li><a href="Allowed_Action.html">Acciones Permitidas</a></li>
          <li><a href="Sec_Objects.html">Objetos</a></li>
          <li><a href="Role.html">Roles</a></li>
          <li><a href="Role_Detail.html">Detalle de Roles</a></li>
          <li><a href="Status.html">Estados</a></li>
          <li><a href="Company.html">Companias</a></li>
          <li><a href="Suscription.html">Suscripciones</a></li>
          <li><a href="Data_Type.html">Tipo de Datos</a></li>
        </ul>
      </li>
      <li><a href="#">Cerrar Session</a></li>
    </ul>
    
  </div>
</nav>
     `
})

    