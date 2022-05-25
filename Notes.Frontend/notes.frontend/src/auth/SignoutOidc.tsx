import { useNavigate } from 'react-router-dom';
import React, { FC, useEffect } from 'react';
import { signoutRedirectCallback } from './user-service';

const SignoutOidc: FC<{}> = () => {
    const navigate = useNavigate();
    useEffect(() => {
        async function signoutAsync() {
            await signoutRedirectCallback();
            navigate('/');
        }
        signoutAsync();
    }, [history]);

    return <div>Redirecting...</div>;
}

export default SignoutOidc;