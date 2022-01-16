import React from 'react';
import './style/character-area.css';

class CharacterArea extends React.Component {

    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="character-area">
                <div className="character-area-content">
                    {this.props.children}
                </div>
            </div>
        );
    }
}

export default CharacterArea;
