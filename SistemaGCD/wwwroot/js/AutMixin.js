var AutMixin = {
    created: function () {
        this.SessionVerify()
    },
    methods: {
        SessionVerify: function () {
            if (sessionStorage.getItem("Id") == null) {
                window.location.href = "/Login.html"
            }
                   }
    }
}