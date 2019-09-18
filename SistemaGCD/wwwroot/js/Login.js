var app = new Vue({
    el: '#app',
    data: {
        modalVisibility: 'none',
        disabledButton: false,
        users: [],
        selectedUsers: {},
        editModUsers: '',
        gridUsers: '',
        inputErrors: []
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
        
    },

    methods: {      
        saveEdit: function () {
            
            var res = ''                
                res = './api/Access/Login'
            
            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(app.selectedUsers)
            })
                .then(function (r) {
                    return r.json()
                    window.location = "https://www.tutorialspoint.com";
                })
                .then(function (data) {
                    
                })
                .catch(function (error) {
                    console.log('Request failed', error);
                });
        }  
    }
})