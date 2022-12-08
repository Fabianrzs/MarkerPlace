import { useState } from 'react';

export const useForm = (initState) => {

    const [state, setState] = useState(initState);

    const onChange = ({value, name}) => {
        setState({
            ...state,
            [name]: value
        });
    }

    return {
        ...state,
        form: state,
        onChange,
    }

}
