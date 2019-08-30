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
    template: `<nav class="w3-sidebar w3-collapse w3-white w3-animate-left" style="z-index:3;width:300px;" id="mySidebar"><br>
 <div class="w3-container">
<hr>    
<h5>Dashboard</h5>
  </div>
  <div class="w3-bar-block">
    <a href="#"  class="w3-bar-item w3-button w3-padding-16 w3-hide-large w3-dark-grey w3-hover-black" onclick="w3_close()" title="close menu"><i class="fa fa-remove fa-fw"></i>  Close Menu</a>    
    <a v-bind:href="hrefs.person" 
        class="w3-bar-item w3-button w3-padding"
        v-bind:class="{'w3-green': currentLocation.indexOf(hrefs.person) > -1 }" 
       >
    <i class="fa fa-bullseye fa-fw"></i>  Principal </a>
    <a v-bind:href="hrefs.student" 
        class="w3-bar-item w3-button w3-padding"
        v-bind:class="{'w3-green': currentLocation.indexOf(hrefs.student) > -1 }" 
       >
    <i class="fa fa-diamond fa-fw"></i>  Flujos </a>
    <a v-bind:href="hrefs.grade" 
        class="w3-bar-item w3-button w3-padding"
        v-bind:class="{'w3-green': currentLocation.indexOf(hrefs.grade) > -1 }" 
       >
     <i class="fa fa-bell fa-fw"></i>  Reportes</a>
    <a v-bind:href="hrefs.level" 
        class="w3-bar-item w3-button w3-padding"
        v-bind:class="{'w3-green': currentLocation.indexOf(hrefs.level) > -1 }" 
       >
    <i class="fa fa-bank fa-fw"></i>  Auditoria</a>
    <a v-bind:href="hrefs.career" 
        class="w3-bar-item w3-button w3-padding"
        v-bind:class="{'w3-green': currentLocation.indexOf(hrefs.career) > -1 }" 
       >
    <i class="fa fa-history fa-fw"></i>  Mantenimiento</a>
    <a v-bind:href="hrefs.Allowed_Action" 
        class="w3-bar-item w3-button w3-padding"
        v-bind:class="{'w3-green': currentLocation.indexOf(hrefs.gender) > -1 }" 
       >
    <i class="fa fa-history fa-fw"></i>  Acciones Permitidas </a>
     <a v-bind:href="hrefs.Object" 
        class="w3-bar-item w3-button w3-padding"
        v-bind:class="{'w3-green': currentLocation.indexOf(hrefs.status) > -1 }" 
       >
    <i class="fa fa-cog fa-fw"></i>  Objetos</a>
     <a v-bind:href="hrefs.param" 
        class="w3-bar-item w3-button w3-padding"
        v-bind:class="{'w3-green': currentLocation.indexOf(hrefs.param) > -1 }" 
       >
    <i class="fa fa-cog fa-fw"></i> Parámetros</a>
    <a v-bind:href="hrefs.quota" 
        class="w3-bar-item w3-button w3-padding"
        v-bind:class="{'w3-green': currentLocation.indexOf(hrefs.quota) > -1 }" 
       >
    <i class="fa fa-cog fa-fw"></i>  Cuota</a>
     <a v-bind:href="hrefs.receipt" 
        class="w3-bar-item w3-button w3-padding"
        v-bind:class="{'w3-green': currentLocation.indexOf(hrefs.receipt) > -1 }" 
       >
    <i class="fa fa-cog fa-fw"></i>  Pagos</a>
    <a href="#" class="w3-bar-item w3-button w3-padding"><i class="fa fa-cog fa-fw"></i>  Settings</a><br><br>
  </div>
 <img src="image/logo.jpg" width="125" height="125" >
</nav>
     `
})