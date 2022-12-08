export default{
    async login (data){
        const response = await fetch('user/login',{
            method: "POST",
            headers:{
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(data)
        });
        return await response.json();
    },
    async register (data){
        const response = await fetch('user/register',{
            method: "POST",
            headers:{
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(data)
        });
        return await response.json();
    },
    async getAllUsers(){
        const response = await fetch('user/AllUsers');
        return response;
    },
    getUsersBy(id){

    },
    changeStateUser(id, state) {

    }
}
