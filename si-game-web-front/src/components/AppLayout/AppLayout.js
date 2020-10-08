import React from 'react';
import classes from './AppLayout.css'

const appLayout = (props) => (
    <div>
        <main /*className={classes.Content}*/ >
            {props.children} 
        </main>
    </div>
);

export default appLayout;