import React from 'react';
import './style/card-list.css';
import Card from './card';

class CardList extends React.Component {

    constructor(props) {
        super(props);
    }

    getCards() {
        var cards = [];

        for (var spell of this.props.data) {
            cards.push(<Card key={spell.data.name} data={spell.data} school={spell.school} />);
        }

        return cards;
    }

    render() {
        return (
            <div className="card-list-container">
                <div className="card-list">

                    <div className="card-list-content">
                        {this.getCards()}
                    </div>
                </div>
            </div>
        );
    }
}

export default CardList;
