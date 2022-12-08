export default{
    async register (data){
        const response = await fetch('product/register',{
            method: "POST",
            headers:{
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(data)
        });
        return await response.json();
    },
    async getAll(){
       try{
           const response = await fetch('product/All');
           return await response.json();
       }catch (e){
           return e
       }
    },
}
