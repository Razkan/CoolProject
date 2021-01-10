import React from 'react';
import './style/main.css';
import SpellTable from './main/spells/spell-table';
import Character from './main/character/character';
import { connect } from 'react-redux';

const mapStateToProps = (state) => ({ sidebar: state.sidebar.value });

class Main extends React.Component {

    getContent() {
        switch(this.props.sidebar) {
            case 'Character':
                return <Character />;
            case 'Spells':
                return <SpellTable />
            case 'Notes':
                break;    
        }

        return null;
    }

    render() {
        return <div className="main">
            {this.getContent()}
        </div>;
    }
}

export default connect(mapStateToProps)(Main);
