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
      <li><a href="#"> Casos</a></li>
      <li><a href="#">Reportes</a></li>
      <li><a href="#">Auditoria</a></li>
      <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Mantenimiento <span class="caret"></span></a>
        <ul class="dropdown-menu">
          <li><a href="#">Usuarios</a></li>
          <li><a href="#">Acciones Permitidas</a></li>
          <li><a href="#">Objetos</a></li>
          <li><a href="#">Roles</a></li>
          <li><a href="#">Detalle de Roles</a></li>
          <li><a href="#">Estados</a></li>
          <li><a href="#">Companias</a></li>
          <li><a href="#">Suscripciones</a></li>
          <li><a href="#">Tipo de Datos</a></li>
        </ul>
      </li>
      <li><a href="#">Cerrar Session</a></li>
    </ul>
    
  </div>
</nav>
     `
})

    