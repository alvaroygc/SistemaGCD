var app = new Vue({
    el: '#app',
    data: {
        modalVisibility: 'none',
        disabledButton: false,
        actions: [],
        selectedAction: {},
        editModAction: '',
        gridAction: '',
        inputErrors: []

    },

    mounted: function () {

    },

    created: function () {
        var self = this;
       
    },

    methods: {
        DestroySession: function () {
            Vue.nextTick(function () {
                //Esto se ejecuta en la proxima iteracion de dibujado de elementos en el DOM.
                if (!confirm("¿Está seguro de Cerrar Session?")) {
                    window.location.href = "/Principal.html"
                }
                else {
                    sessionStorage.clear()
                    window.location.href = "/Login.html"
                }
            }
          )}      
    }
})