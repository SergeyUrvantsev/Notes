import { FC, ReactElement } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css';
import userManager, { loadUser, signinRedirect, signoutRedirect } from './auth/user-service';
import AuthProvider from './auth/auth-provider';
import SignInOidc from './auth/SigninOidc';
import SignOutOidc from './auth/SignoutOidc';
import NoteList from './notes/NoteList';


const App: FC<{}> = (): ReactElement => {
    loadUser();
  return (
    <div className="App">
      <header className="App-header">
              <button onClick={() => signinRedirect()}>Login</button>
              <AuthProvider userManager={userManager}>
                  <Router>
                      <Routes>
                          <Route path="/" children={<NoteList />} />
                          <Route path="/signout-oidc" children={<SignInOidc />} />
                          <Route path="/signit-oidc" children={<SignOutOidc />} />
                      </Routes>
                  </Router>
              </AuthProvider>
      </header>
    </div>
  );
}

export default App;
