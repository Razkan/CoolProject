import React from 'react';
import './style/start-page.css';

import {
    Switch,
    Route,
    Link
} from "react-router-dom";

import Navigation from './navigation';

import AnimaSidebarPage from './../../anima/pages/anima-sidebar-page';
import AnimaMainPage from './../../anima/pages/anima-main-page';

import MageSidebarPage from './../../mage/pages/mage-sidebar-page';
import MageMainPage from './../../mage/pages/mage-main-page';


import anima from './../images/system/anima.jpg' 
import mage from './../images/system/mage_2nd_edition.jpg'

class StartPage extends React.Component {

    render() {
        return(
            <div className="start-page-container">
                <Switch>
                    <Route path="/Anima">
                        {/* <Navigation /> */}
                        <div className="content">
                            <AnimaSidebarPage />
                            <AnimaMainPage />
                        </div>
                    </Route>
                    
                    <Route path="/Mage">
                        {/* <Navigation /> */}
                        <div className="content">
                            <MageSidebarPage />
                            <MageMainPage />
                        </div>
                    </Route>

                    <Route path="/">
                        <div className="start-page">
                            <Link to="/Anima">
                                <div className="start-page-card">
                                    <img src={anima} alt={"Anima"} />
                                    <div className="start-page-card-container">
                                        <h4><b>Anima</b></h4> 
                                        <p>Something</p> 
                                    </div>
                                </div>
                            </Link>

                            <Link to="/Mage">
                                <div className="start-page-card">
                                    <img src={mage} alt={"mage"} />
                                    <div className="start-page-card-container">
                                        <h4><b>Mage</b></h4> 
                                        <p>Something</p> 
                                    </div>
                                </div>                        
                            </Link>
                        </div>
                    </Route>
                </Switch>
            </div>
        );
    }
}

export default StartPage;