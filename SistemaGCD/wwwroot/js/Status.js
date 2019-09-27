var app = new Vue({
    el: '#app',
    mixins: [AutMixin],
    data: {
        modalVisibility: 'none',
        disabledButton: false,
        status: [],
        selectedStatus: {},
        editModStatus: '',
        gridStatus: '',
        inputErrors: []
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
        self.getStatus();
    },

    methods: {
        getStatus: function () {
            fetch('./api/Status/getall', {
                method: 'GET',
                headers: {
                    'LoggedUser': sessionStorage.getItem('Id')
                }
            })
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.status = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

        openEditModal: function (action, mode) {
            app.modalVisibility = "block"
            app.editModStatus = mode
            if (mode == "EDIT") {
                app.gridStatus = "Editar";
                app.selectedStatus = Object.assign({}, action)
            }
            if (mode == "NEW") {
                app.gridStatus = "Nuevo";
                app.selectedStatus = { name: '', description: '' }
            }
        },
        closeModal: function () {
            app.modalVisibility = "none"
        },

        validateActionInput: function () {
            app.inputErrors = []
            if (app.selectedStatus.name == '') {
                app.inputErrors.push('El nombre no debe ser vacío!')
            }
            if (app.selectedStatus.description == '') {
                app.inputErrors.push('Ingrese una descripcion!');
            }
        },

        saveEdit: function () {
            var res = ''
            //validar
            app.validateActionInput();
            if (app.inputErrors.length > 0) {
                return;
            }
            if (app.editModStatus == "EDIT") {
                res = '/api/Status/update'
            }
            if (app.editModStatus == "NEW") {
                res = '/api/Status/create'
            }
            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json",
                    "LoggedUser": sessionStorage.getItem("Id")
                },
                body: JSON.stringify(app.selectedStatus)
            })
                .then(function (r) {
                    return r.json()
                })
                .then(function (data) {
                    app.closeModal()
                    app.getStatus()
                })
                .catch(function (error) {
                    console.log('Request failed', error);
                });
        },

        DeleteStatus: function (action) {
            app.modalVisibility = "block"
            app.selectedStatus = Object.assign({}, action)
            Vue.nextTick(function () {
                //Esto se ejecuta en la proxima iteracion de dibujado de elementos en el DOM.
                if (!confirm("¿Está seguro de eliminar?")) {
                    app.closeModal()
                    return;
                }
                fetch('/api/Status/Delete', {
                    method: 'post',
                    headers: {
                        "Content-Type": "application/json",
                        "LoggedUser": sessionStorage.getItem("Id")
                    },
                    body: JSON.stringify(app.selectedStatus)
                })
                    .then(function (r) {
                        return r.json()
                    })
                    .then(function (data) {
                        //alert(data.result)
                        app.closeModal()
                        app.getStatus()
                    })
                    .catch(function (error) {
                        console.log('Request failed', error);
                    });
            })
        }
    }
})