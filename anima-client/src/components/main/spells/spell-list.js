import React from 'react';
import './style/spell-list.css';
import Spell from './spell';

class SpellList extends React.Component {

    constructor(props) {
        super(props);
    }

    getSpells() {
        var spells = [];

        for (var spell of this.props.data) {
            spells.push(<Spell key={spell.data.name} data={spell.data} school={spell.school} />);
        }

        return spells;
    }

    render() {
        return (
            <div className="spell-list-container">
                <div className="spell-list">

                    <div className="spell-list-content">
                        {this.getSpells()}
                    </div>
                </div>
            </div>
        );
    }
}

export default SpellList;
