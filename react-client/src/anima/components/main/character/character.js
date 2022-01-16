import React from 'react';
import './style/character.css';
import CharacterArea from './character-area';

class Character extends React.Component {

    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="character">
                <CharacterArea>
                    Earth:
                    <input></input>
                </CharacterArea>
            </div>
        );
    }
}

export default Character;
