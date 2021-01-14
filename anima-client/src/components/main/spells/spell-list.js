import React from 'react';
import './style/spell-list.css';
import Spell from './spell';

class SpellList extends React.Component {

    constructor(props) {
        super(props);
    }

    getSpells() {
        var spells = [];

        for(const [key, value] of Object.entries(this.props.books)) {
            for(var book of value) {
                for(var spell of book.spells) {
                    
                    switch(key) {
                        case 'core':
                            spells.push(<Spell key={spell.name} data={spell} school={book.school} />);
                            break;
    
                        case 'arcana':
                            spells.push(<Spell key={spell.name} data={spell} school={book.school} />);
                            break;
                    } 
                }

            }
        }

        spells = spells.sort((a, b) => {
            if (a.props.data.level > b.props.data.level) return 1;
            if (a.props.data.level < b.props.data.level) return -1;

            if (a.props.data.cost > b.props.data.cost) return 1;
            if (a.props.data.cost < b.props.data.cost) return -1;

            if (a.props.data.name > b.props.data.name) return 1;
            if (a.props.data.name < b.props.data.name) return -1;

            return 0;
        });

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
