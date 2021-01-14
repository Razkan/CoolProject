import React from 'react';
import SpellTable from './../components/main/spells/spell-table';

class SpellPage extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            query = "",
            bookData: {},
            subpathData: {},
        };

        this.fetch = this.fetch.bind(this);
        this.retryFetch = this.retryFetch.bind(this);

        this.baseUrl = "http://localhost:9422/";
        this.endpoints = [
            this.baseUrl + "spellbook/all",
            this.baseUrl + "subpathspellbook/all"
        ];

        this.retry = null;
    }

    fetchWithQuery = query => this.setState({ query }, () => this.fetchData());

    fetchData() {
        // for (var endpoint of endpoints) {
        //     this.fetchData(endpoint + this.state.query, () => {}, this.retryFetch)
        // }
    }

    // componentDidMount() {
    //     this.fetchData(this.bookUrl, this.setupBooks, this.retryFetch)
    //         .then(() => this.fetchData(this.subpathUrl, this.setupSubpaths, this.retryFetch));
    // }

    async fetch(url, onSuccess, onFailure) {
        console.time("fetch");
        try {
            var response = await fetch(url);
            var body = await response.json();
            onSuccess(body);
        }
        catch (err) {
            onFailure(err, url, onSuccess, onFailure);
        }
        console.timeEnd("fetch");
    }

    retryFetch(error, url, onSuccess, onFailure) {
        console.log(error);
        console.log("Retrying in 1 minute");
        console.log(url);

        if (this.retry) {
            clearTimeout(this.retry);
        }

        this.retry = setTimeout(() => {
            this.fetch(url, onSuccess, onFailure)
        }, 60000);
    }

    render() {
        return (
            <SpellTable />
        );
    }
}

export default SpellPage;
